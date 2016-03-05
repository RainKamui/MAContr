using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetServer.TcpServer.Protocols {
	class CommandProtocol : Protocol {
		private byte[] _data;

		public override byte[] Data {
			get { return _data; }
			set { _data = value; }
		}

		public CommandProtocol(byte[] data) {
			this._data = data;
		}

		public CommandProtocol(string result) {
			this._data = Encoding.UTF8.GetBytes(result);
		}

		public override object FormatReceiveProtocol() {
			return Encoding.UTF8.GetString(this._data);
		}

	}
}
