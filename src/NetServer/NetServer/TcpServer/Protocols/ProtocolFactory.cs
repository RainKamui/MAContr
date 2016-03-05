using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetServer.TcpServer.Protocols {
	public class ProtocolFactory {
		public static Protocol CreateProtocol(ProtocolType protocolType) {
			switch (protocolType) {
				case ProtocolType.C2SScreenShot:
					return new ScreenProtocol();

				default: return null;
			}
		}
	}
}
