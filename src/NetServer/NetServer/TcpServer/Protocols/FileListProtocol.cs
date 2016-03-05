using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace NetServer.TcpServer.Protocols {
	class FileListProtocol : Protocol {
		private byte[] _data;

		public override byte[] Data {
			get { return _data; }
			set { _data = value; }
		}

		public FileListProtocol(byte[] data) {
			this._data = data;

		}

		private string _path = string.Empty;

		public string Path {
			get {
				return _path;
			}
		}

		public FileListProtocol(string path) {
			if (Directory.Exists(path)) {
				DirectoryInfo folder = new DirectoryInfo(path);

				StringBuilder directoryStringBuilder = new StringBuilder();
				/*
				string currentDirectory = ".:Current Direcrory";
				directoryStringBuilder.Append(currentDirectory + '*');
				string seniorDirectory = "..:Senior Directory";
				directoryStringBuilder.Append(seniorDirectory + '*');
				 */
				string directoryString = string.Empty;
				//如果这个文件夹中有文件夹
				if (folder.GetDirectories().Length != 0) {
					foreach (DirectoryInfo directoryInfo in folder.GetDirectories()) {
						string directory = directoryInfo.Name + ':' + directoryInfo.LastWriteTime;
						directoryStringBuilder.Append(directory + '*');
					}
					directoryString = directoryStringBuilder.ToString().Substring(0, directoryStringBuilder.Length - 1);
				}


				StringBuilder fileStringBuilder = new StringBuilder();
				string fileString = string.Empty;
				//如果文件夹下面有文件
				if (folder.GetFiles().Length != 0) {
					foreach (FileInfo fileInfo in folder.GetFiles()) {
						string file = fileInfo.Name + ':' + (float)((float)fileInfo.Length / 1024.0f) + "KB";
						fileStringBuilder.Append(file + '*');
					}
					fileString = fileStringBuilder.ToString().Substring(0, fileStringBuilder.Length - 1);
				}

				string completeString = path + '|' + directoryString + '|' + fileString;
				this._data = Encoding.UTF8.GetBytes(completeString);
				this._path = folder.FullName;
			}
		}

		public override object FormatReceiveProtocol() {
			string fileListString = Encoding.UTF8.GetString(_data);
			List<string[]> pathInfo = new List<string[]>();

			string[] DAF = fileListString.Split('|');
			string path = DAF[0];
			string directorys = DAF[1];
			string files = DAF[2];

			this._path = path;

			if (directorys != string.Empty) {
				string[] directory = directorys.Split('*');
				pathInfo.Add(directory);
			}
			else {
				pathInfo.Add(null);
			}

			if (files != string.Empty) {
				string[] file = files.Split('*');
				pathInfo.Add(file);
			}
			else {
				pathInfo.Add(null);
			}

			return pathInfo;

		}
	}
}
