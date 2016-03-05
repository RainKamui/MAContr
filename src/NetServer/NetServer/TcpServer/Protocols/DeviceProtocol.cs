using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace NetServer.TcpServer.Protocols {
	class DeviceProtocol : Protocol {
		private static readonly double _gbByte = 1073741824.0d;

		private byte[] _data;

		public override byte[] Data {
			get { return _data; }
			set { _data = value; }
		}

		public DeviceProtocol(byte[] data) {
			this._data = data;
		}

		public DeviceProtocol() {
			DriveInfo[] devices = DriveInfo.GetDrives();
			StringBuilder deviceStringBuilder = new StringBuilder();
			foreach (DriveInfo deviceInfo in devices) {
				long totalSize = 0;
				long freeSize = 0;
				try {
					totalSize = deviceInfo.TotalSize;
				}
				catch {
				}
				try {
					freeSize = deviceInfo.TotalFreeSpace;
				}
				catch {
				}
				string free = ((double)freeSize / _gbByte).ToString();
				string total = ((double)totalSize / _gbByte).ToString();
				free = free.Length > 4 ? free.Substring(0, 4) : free;
				total = total.Length > 4 ? total.Substring(0, 4) : total;


				string device = deviceInfo.Name + '*' + free + "GB / " + total + "GB";
				deviceStringBuilder.Append(device + '|');
			}
			string deviceString = deviceStringBuilder.ToString().Substring(0, deviceStringBuilder.Length - 1);
			_data = Encoding.UTF8.GetBytes(deviceString);
		}

		public override object FormatReceiveProtocol() {
			string deviceString = Encoding.UTF8.GetString(_data);
			string[] devices = deviceString.Split('|');
			List<string> deviceList = new List<string>(devices);
			return deviceList;
		}

	}
}
