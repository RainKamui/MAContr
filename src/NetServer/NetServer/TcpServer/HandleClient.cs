using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using NetServer.TcpServer.Protocols;

//updata 功能


namespace NetServer.TcpServer {


	public class HandleClient {

		#region Fields

		private static string _getIpLocation = @"http://whois.pconline.com.cn/ip.jsp?ip=";
		private static readonly object _syncRelease = new object();
		private TcpClient _tcpClient = null;

		private Queue<byte> _byteQueue = new Queue<byte>();
		private Queue<byte[]> _responseQueue = new Queue<byte[]>();
		private enum DataState { Head, Data };
		private DataState _dataState = DataState.Head;

		private DataHead _currentHead = null;
		private string _clientId = string.Empty;
		private int _clientVersion = 0;
		private int[] _screenInfo = new int[2];
		private bool _hasCamera = false;

		private long _lastHeartbeatTime = 0;

		#endregion

		#region Property
		public TcpClient TcpClient {
			get {
				return _tcpClient;
			}
		}

		public string ClientId {
			get {
				return _clientId;
			}
		}

		public bool Connected {
			get {
				if (_tcpClient == null)
					return false;
				try {
					if ((_tcpClient.Client.Poll(20, SelectMode.SelectRead)) && (_tcpClient.Client.Available == 0))
						return false;
				}
				catch {
					return false;
				}
				return true;
			}
		}


		public bool IsAlive { set; get; }
		#endregion

		#region Events
		public PassImageEventHandler OnShowScreen { set; get; }
		public PassImageEventHandler OnShowCamera { set; get; }
		public PassMessageEventHandler OnShowMessage { set; get; }
		public PassMessageEventHandler OnShowCommandResult { set; get; }
		public PassDeviceEventHandler OnShowDevice { set; get; }
		public PassMessageEventHandler OnShowPath { set; get; }
		public PassFileListEventHandler OnShowFileList { set; get; }

		public PassHandleClientHandler OnAddClient { set; get; }
		public PassMessageEventHandler OnDeleteClient { set; get; }
		#endregion

		#region Construct
		public HandleClient(TcpClient _tmpTcpClient) {
			this._tcpClient = _tmpTcpClient;
			this.IsAlive = true;
			this._lastHeartbeatTime = UnixTimeNow();
		}
		#endregion

		#region ReleaseHandle
		/// <summary>
		/// 释放所有资源，关闭此Handle线程
		/// </summary>
		private void ReleaseHandle() {
			lock (_syncRelease) {
				OnDeleteClient(_clientId);
				OnShowMessage("Client : " + _clientId + " disconnect");
				if (_tcpClient != null) {
					try {
						_tcpClient.Close();
					}
					finally {
						_tcpClient = null;
					}
				}
				if (_byteQueue != null) {
					_byteQueue.Clear();
					_byteQueue = null;
				}

				if (_responseQueue != null) {
					_responseQueue.Clear();
					_responseQueue = null;
				}

				Thread.CurrentThread.Abort();

			}
		}
		#endregion

		#region ReceiveHandle
		/// <summary>
		/// Receive处理线程
		/// 从Stream里Receive数据并处理
		/// </summary>
		public void ReceiveHandle() {
			while (true) {
				if (IsAlive) {
					try {
						ReceiveByte();
					}
					catch (Exception ex) {
						ReleaseHandle();
					}
					Application.DoEvents();
					Thread.Sleep(200);
					
				}
			}
		}
		#endregion

		#region SendHanle
		/// <summary>
		/// Send处理线程
		/// 从Queue中获取数据并通过NetworkStream发送
		/// </summary>
		public void SendHandle() {
			while (true) {
				if (IsAlive) {
					try {
						lock (_responseQueue) {
							SendQueue();
						}
					}
					catch {
						ReleaseHandle();
					}
				}
				Application.DoEvents();
				Thread.Sleep(200);
			}
		}
		#endregion

		public void AddDataHead(Protocols.ProtocolType type, string tag = "", int dataLength = 0) {
			DataHead head = new DataHead(dataLength, type, tag);
			byte[] data = head.GetHeadByte();
			lock (_responseQueue) {
				_responseQueue.Enqueue(data);
			}
		}

		public void SendQueue() {
			//while (true) {
			try {
				if (_tcpClient != null) {
					while (_responseQueue.Count > 0) {
						NetworkStream networkStream = _tcpClient.GetStream();
						byte[] data = _responseQueue.Dequeue();
						DataHead head = new DataHead(data);
						OnShowMessage("Send Message : " + head.HeadType + "  " + head.Tag.TrimEnd('\0'));
						if (networkStream.CanWrite) networkStream.Write(data, 0, data.Length);
					}

					if (UnixTimeNow() - _lastHeartbeatTime > 2000) {
						NetworkStream networkStream = _tcpClient.GetStream();
						DataHead heartbeat = new DataHead(0, Protocols.ProtocolType.S2CHeartbeat, "");
						if (networkStream.CanWrite) networkStream.Write(heartbeat.GetHeadByte(), 0, DataHead.Size);

					}
				}
			}
			catch {
				ReleaseHandle();
			}

			//Thread.Sleep(100);
			//Application.DoEvents();
			//}

		}

		#region RunQueue
		/// <summary>
		/// 执行队列
		/// </summary>
		private void RunQueue() {
			while ((_dataState == DataState.Head && _byteQueue.Count >= DataHead.Size) || (_dataState == DataState.Data && _byteQueue.Count >= _currentHead.DataLength)) {
				switch (_dataState) {
					case DataState.Head:
						if (_byteQueue.Count >= DataHead.Size) {
							byte[] headByte = new byte[DataHead.Size];
							for (int i = 0; i < DataHead.Size; i++) {
								headByte[i] = _byteQueue.Dequeue();
							}
							_currentHead = new DataHead(headByte);
							ParseHead(_currentHead);
							if (_currentHead.DataLength != 0) _dataState = DataState.Data;
						}
						break;
					case DataState.Data:
						if (_byteQueue.Count >= _currentHead.DataLength) {
							byte[] dataByte = new byte[_currentHead.DataLength];
							for (int i = 0; i < _currentHead.DataLength; i++) {
								dataByte[i] = _byteQueue.Dequeue();
							}
							ParseData(dataByte);
							_dataState = DataState.Head;
						}
						break;
				}
			}

		}
		#endregion

		#region ReceiveByte
		/// <summary>
		/// 从Stream获取byte并存入队列等待处理
		/// </summary>
		private void ReceiveByte() {
			try {
				NetworkStream stream = _tcpClient.GetStream();
				int buffSize = _tcpClient.ReceiveBufferSize;

				byte[] myReadBuffer = null;
				if (stream.CanRead) {
					myReadBuffer = new byte[buffSize];
					int numberOfBytesRead = 0;
					do {
						//阻塞接受数据
						numberOfBytesRead = stream.Read(myReadBuffer, 0, buffSize);
						if (numberOfBytesRead != 0) {
							for (int i = 0; i < numberOfBytesRead; i++) {
								_byteQueue.Enqueue(myReadBuffer[i]);
							}
							//尝试处理
							RunQueue();
						}
					}
					while (stream.DataAvailable);
				}
				else
					OnShowMessage("Sorry.  You cannot read from this NetworkStream.");
			}
			catch (Exception ex) {
				ReleaseHandle();
			}
		}
		#endregion

		#region ParseData
		/// <summary>
		/// 处理接受的Protocol
		/// </summary>
		/// <param name="dataByte">The data of Protocol</param>
		private void ParseData(byte[] dataByte) {
			switch (_currentHead.HeadType) {
				case Protocols.ProtocolType.C2SScreenShot:
					try {
						ScreenProtocol screenProtocol = new ScreenProtocol(dataByte);
						if (screenProtocol != null) {
							OnShowScreen((Image)screenProtocol.FormatReceiveProtocol());
						}
					}
					catch (Exception ex) {
						MessageBox.Show(ex.ToString());
					}
					break;

				case Protocols.ProtocolType.C2SCamera:
					try {
						CameraProtocol cameraProtocol = new CameraProtocol(dataByte);
						OnShowCamera((Image)cameraProtocol.FormatReceiveProtocol());
					}
					catch (Exception ex) {
						MessageBox.Show(ex.ToString());
					}
					break;

				case Protocols.ProtocolType.C2SCommandResult:
					CommandProtocol commandProtocol = new CommandProtocol(dataByte);
					string result = (string)commandProtocol.FormatReceiveProtocol();
					OnShowCommandResult(result);
					break;

				case Protocols.ProtocolType.C2SDeviceList:
					DeviceProtocol deviceProtocol = new DeviceProtocol(dataByte);
					List<string> devices = (List<string>)deviceProtocol.FormatReceiveProtocol();
					OnShowPath(string.Empty);
					OnShowDevice(devices);
					break;

				case Protocols.ProtocolType.C2SFileList:
					FileListProtocol fileListProtocol = new FileListProtocol(dataByte);
					List<string[]> fileList = (List<string[]>)fileListProtocol.FormatReceiveProtocol();
					OnShowPath(fileListProtocol.Path);
					OnShowFileList(fileList);
					break;

			}
		}
		#endregion

		#region ParseHead
		/// <summary>
		/// 处理DataHead
		/// </summary>
		/// <param name="head"></param>
		private void ParseHead(DataHead head) {
			switch (head.HeadType) {
				case Protocols.ProtocolType.C2SMessage:
					string[] split = head.Tag.Split(';');
					_clientVersion = Convert.ToInt32(split[0]);
					_clientId = split[1];
					_screenInfo[0] = Convert.ToInt32(split[2].Split('x')[0]);
					_screenInfo[1] = Convert.ToInt32(split[2].Split('x')[1]);
					_hasCamera = split[3] == "hasCamera:1";


					string clientIpPort = string.Empty;
					string location = string.Empty;
					if (_tcpClient.Client != null && _tcpClient.Client.RemoteEndPoint != null) {
						clientIpPort = ((IPEndPoint)_tcpClient.Client.RemoteEndPoint).Address.ToString();
						location = GetPageASCII(_getIpLocation + clientIpPort);
						clientIpPort += ":" + ((IPEndPoint)_tcpClient.Client.RemoteEndPoint).Port.ToString();
					}

					OnAddClient(_clientId + "|" + clientIpPort + "|" + location, this);
					OnShowMessage("Client : " + _clientId + " has connected; ClientVersion:" + _clientVersion + " Resolution:" + split[2] + " " + split[3]);

					//如果收到的是客户端的登录信息，则结束此线程，保留Handle引用，以便之后开启。
					//Thread.CurrentThread.Abort();
					//双击lsv_Client 开启Alive
					IsAlive = false;
					break;
			}
		}
		#endregion

		#region Helper Function
		public long UnixTimeNow() {
			TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
			return Convert.ToInt64(ts.TotalMilliseconds);
		}
		public static string GetPageASCII(string url) {
			return GetPage(url, Encoding.Default);
		}

		public static string GetPageUTF8(string url) {
			return GetPage(url, Encoding.UTF8);
		}

		public static string GetPage(string url, Encoding encoding) {
			HttpWebRequest request = null;
			HttpWebResponse response = null;
			StreamReader reader = null;
			try {
				request = (HttpWebRequest)WebRequest.Create(url);
				request.UserAgent = "User-Agent:Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705";
				request.Timeout = 20000;
				request.AllowAutoRedirect = false;
				response = (HttpWebResponse)request.GetResponse();
				if (response.StatusCode == HttpStatusCode.OK && response.ContentLength < 1024 * 1024) {
					reader = new StreamReader(response.GetResponseStream(), encoding);
					string html = reader.ReadToEnd();
					return html;
				}
			}
			catch { }
			finally {
				if (response != null) {
					response.Close();
					response = null;
				}
				if (reader != null)
					reader.Close();
				if (request != null)
					request = null;
			}
			return string.Empty;
		}


		#endregion

	}
}
