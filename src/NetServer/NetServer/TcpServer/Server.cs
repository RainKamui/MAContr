using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace NetServer.TcpServer {
	public delegate void PassImageEventHandler(Image image);
	public delegate void PassMessageEventHandler(string message);
	public delegate void PassDeviceEventHandler(List<string> deviceList);
	public delegate void PassFileListEventHandler(List<string[]> fileList);
	public delegate void PassHandleClientHandler(string tag, HandleClient client);

	public class Server {
		private static int PORT = 8117;
		private TcpListener tcpListener = null;

		public PassImageEventHandler OnShowScreen { set; get; }
		public PassImageEventHandler OnShowCamera { set; get; }
		public PassMessageEventHandler OnShowMessage { set; get; }
		public PassMessageEventHandler OnShowCommandResult { set; get; }
		public PassDeviceEventHandler OnShowDevice { set; get; }
		public PassMessageEventHandler OnShowPath { set; get; }
		public PassFileListEventHandler OnShowFileList { set; get; }

		public PassHandleClientHandler OnAddClient { set; get; }
		public PassMessageEventHandler OnDeleteClient { set; get; }



		public void ListenToConnection() {

			IPEndPoint ipe = new IPEndPoint(IPAddress.Any, PORT);

			tcpListener = new TcpListener(ipe);
			tcpListener.Start();

			TcpClient tmpTcpClient = null;


			while (true) {
				try {
					tmpTcpClient = tcpListener.AcceptTcpClient();

					if (tmpTcpClient.Connected) {
						HandleClient handleClient = new HandleClient(tmpTcpClient);

						handleClient.OnShowScreen = this.OnShowScreen;
						handleClient.OnShowCamera = this.OnShowCamera;
						handleClient.OnShowMessage = this.OnShowMessage;
						handleClient.OnShowCommandResult = this.OnShowCommandResult;
						handleClient.OnShowDevice = this.OnShowDevice;
						handleClient.OnShowPath = this.OnShowPath;
						handleClient.OnShowFileList = this.OnShowFileList;
						handleClient.OnAddClient = this.OnAddClient;
						handleClient.OnDeleteClient = this.OnDeleteClient;

						Thread receiveThread = new Thread(new ThreadStart(handleClient.ReceiveHandle));
						receiveThread.IsBackground = true;
						receiveThread.Start();

						Thread sendThread = new Thread(new ThreadStart(handleClient.SendHandle));
						sendThread.IsBackground = true;
						sendThread.Start();
						

					}
				}
				catch (Exception ex) {
					Console.WriteLine(ex.Message);
					Console.Read();
				}

				Application.DoEvents();
			}
		}
	}
}
