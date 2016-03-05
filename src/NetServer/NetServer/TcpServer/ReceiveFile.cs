using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.IO;

namespace NetServer.TcpServer {
	class ReceiveFile {
		private static readonly int _port = 8118;
		public static string _downloadDirectory = @"E:\ServerDownload\";
		private string _file = string.Empty;
		private string _serverIp = string.Empty;

		public void StartReceive() {

			IPEndPoint ipep = new IPEndPoint(IPAddress.Any, _port);
			Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			server.Bind(ipep);

			server.Listen(10);
			Socket client = null;



			while (true) {
				try {
					client = server.Accept();
					
					if (client.Connected) {
						IPEndPoint clientep = (IPEndPoint)client.RemoteEndPoint;
						string SendFileName = System.Text.Encoding.Unicode.GetString(ReceiveVarData(client));

						string bagSize = System.Text.Encoding.Unicode.GetString(ReceiveVarData(client));
						int bagCount = int.Parse(System.Text.Encoding.Unicode.GetString(ReceiveVarData(client)));
						string bagLast = System.Text.Encoding.Unicode.GetString(ReceiveVarData(client));

						FileStream MyFileStream = new FileStream(_downloadDirectory + SendFileName, FileMode.Create, FileAccess.Write);

						int SendedCount = 0;

						while (true) {
							byte[] data = ReceiveVarData(client);
							if (data.Length == 0) {
								break;
							}
							else {
								SendedCount++;
								MyFileStream.Write(data, 0, data.Length);
							}
						}

						MyFileStream.Close();
						client.Close();

						MessageBox.Show("文件接收完毕!");

					}
				}
				catch (Exception ex) {
					Console.WriteLine(ex.Message);
					Console.Read();
				}

				Application.DoEvents();
			}




			//填加到dgv里  
			//文件大小，IP，已发送包的个数，文件名，包的总量，最后一个包的大小  
			//this.dataGridView1.Rows.Add(bagSize, clientep.Address, SendedCount, SendFileName, bagCount, bagLast);

			//MessageBox.Show("文件接收完毕!");  

		}

		private void StartSend() {

			FileInfo EzoneFile = new FileInfo(_file);
			FileStream EzoneStream = EzoneFile.OpenRead();
			//包的大小  
			int PacketSize = 2048;
			//包的数量  
			int PacketCount = (int)(EzoneStream.Length / ((long)PacketSize));
			//最后一个包的大小  
			int LastDataPacket = (int)(EzoneStream.Length - ((long)(PacketSize * PacketCount)));


			IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(_serverIp), _port);
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
			}

			if (LastDataPacket != 0) {
				data = new byte[LastDataPacket];
				EzoneStream.Read(data, 0, data.Length);
				SendVarData(client, data);
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
