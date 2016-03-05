using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;
using NetServer;

namespace NetServer.TcpServer.Protocols {
	class ScreenProtocol : Protocol {
		private byte[] _data;

		public override byte[] Data {
			get { return _data; }
			set { _data = value; }
		}

		public ScreenProtocol() {
		}


		public ScreenProtocol(byte[] data) {
			_data = data;
		}

		public override object FormatReceiveProtocol(/*byte[] data*/) {
			ushort protocolType = BitConverter.ToUInt16(_data, 0);
			MemoryStream ms = new MemoryStream(_data, 0, _data.Length);
			Image image = Image.FromStream(ms);
			return image;
		}

		public static byte[] GetFullScreenByte() {
			Bitmap myImage = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
			Graphics g = Graphics.FromImage(myImage);
			g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height));
			IntPtr dc1 = g.GetHdc();
			g.ReleaseHdc(dc1);
			MemoryStream ms = new MemoryStream();
			myImage.Save(ms, ImageFormat.Jpeg);
			byte[] data = ms.GetBuffer();
			ms.Flush();
			return data;
		}

	}

}
