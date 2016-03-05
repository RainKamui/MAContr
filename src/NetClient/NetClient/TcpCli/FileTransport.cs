using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Threading;

namespace NetServer.TcpServer {
	class FileTransport {
		public static string ServerIP { set; get; }
		public static readonly int _port = 8118;
		private static Queue<string> _filePathList = new Queue<string>();

		public static void AddFile(string path) {
			if (!_filePathList.Contains(path))
				_filePathList.Enqueue(path);
		}

		public static void SendFile() {
			while (true) {
				if (_filePathList.Count > 0) {
					string filePath = _filePathList.Dequeue();
					try {
						StartSend(filePath);
					}
					catch {
					}
				}
				Application.DoEvents();
				Thread.Sleep(2000);

			}
		}

		private static void StartSend(string file) {

			FileInfo EzoneFile = new FileInfo(file);
			FileStream EzoneStream = EzoneFile.OpenRead();
			//包的大小  
			int PacketSize = 2048;
			//包的数量  
			int PacketCount = (int)(EzoneStream.Length / ((long)PacketSize));
			//最后一个包的大小  
			int LastDataPacket = (int)(EzoneStream.Length - ((long)(PacketSize * PacketCount)));


			IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ServerIP), _port);
			Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			client.Connect(ipep);


			IPEndPoint clientep = (IPEndPoint)client.RemoteEndPoint;
			SendVarData(client, System.Text.Encoding.Unicode.GetBytes(EzoneFile.Name));
			SendVarData(client, System.Text.Encoding.Unicode.GetBytes(PacketSize.ToString()));
			SendVarData(client, System.Text.Encoding.Unicode.GetBytes(PacketCount.ToString()));
			SendVarData(client, System.Text.Encoding.Unicode.GetBytes(LastDataPacket.ToString()));

			byte[] data = new byte[PacketSize];
			for (int i = 0; i < PacketCount; i++) {
				EzoneStream.Read(data, 0, data.Length);
				SendVarData(client, data);
				Application.DoEvents();
			}

			if (LastDataPacket != 0) {
				data = new byte[LastDataPacket];
				EzoneStream.Read(data, 0, data.Length);
				SendVarData(client, data);
				Application.DoEvents();
			}

			client.Close();
			EzoneStream.Close();

		}

		public static int SendVarData(Socket s, byte[] data) {
			int total = 0;
			int size = data.Length;
			int dataleft = size;
			int sent;
			byte[] datasize = new byte[4];
			datasize = BitConverter.GetBytes(size);
			sent = s.Send(datasize);

			while (total < size) {
				sent = s.Send(data, total, dataleft, SocketFlags.None);
				total += sent;
				dataleft -= sent;
			}

			return total;
		}

		public static byte[] ReceiveVarData(Socket s) {
			int total = 0;
			int recv;
			byte[] datasize = new byte[4];
			recv = s.Receive(datasize, 0, 4, SocketFlags.None);
			int size = BitConverter.ToInt32(datasize, 0);
			int dataleft = size;
			byte[] data = new byte[size];
			while (total < size) {
				recv = s.Receive(data, total, dataleft, SocketFlags.None);
				if (recv == 0) {
					data = null;
					break;
				}
				total += recv;
				dataleft -= recv;
			}
			return data;
		}

	}
}
