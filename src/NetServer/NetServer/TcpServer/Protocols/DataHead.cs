using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetServer.TcpServer.Protocols {
	class DataHead {
		public static readonly int Size = 256;

		public int DataLength { set; get; }
		public ProtocolType HeadType { set; get; }
		public string _tag = string.Empty;

		public string Tag {
			set {
				_tag = value;
			}
			get {
				return _tag.TrimEnd('\0');
			}
		}

		public byte[] GetHeadByte() {
			byte[] formated = new byte[Size];
			byte[] byteType = BitConverter.GetBytes((ushort)this.HeadType);
			byte[] dataLength = BitConverter.GetBytes(this.DataLength);
			byte[] tag = Encoding.UTF8.GetBytes(this._tag);

			int index = 0;

			foreach (byte data in dataLength) {
				formated[index] = data;
				index++;
			}

			foreach (byte data in byteType) {
				formated[index] = data;
				index++;
			}

			foreach (byte data in tag) {
				formated[index] = data;
				index++;
			}

			/*
			formated = Utils.BytesOperations.BytesUnion(formated, BitConverter.GetBytes(this.DataLength));
			formated = Utils.BytesOperations.BytesUnion(formated, byteType);
			formated = Utils.BytesOperations.BytesUnion(formated, tag);
			 * */

			return formated;
		}

		public DataHead(int dataLength, ProtocolType type, string tag) {
			this.DataLength = dataLength;
			this.HeadType = type;
			this._tag = tag;
		}

		public DataHead(byte[] bytes) {
			DataLength = BitConverter.ToInt32(bytes, 0);
			HeadType = (ProtocolType) BitConverter.ToUInt16(bytes, 4);
			Tag = Encoding.UTF8.GetString(bytes, 6, 250);

		}

	}
}
