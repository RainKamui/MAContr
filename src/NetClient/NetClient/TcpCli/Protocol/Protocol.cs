using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetServer.TcpServer.Protocols
{
    public abstract class Protocol
    {
        public abstract byte[] Data { set; get; }
        public abstract object FormatReceiveProtocol(/*byte[] data*/);


        public static ProtocolType GetType(Protocol pro)
        {
            return (ProtocolType)BitConverter.ToUInt16(pro.Data, 0);
        }

        public static ProtocolType GetType(byte[] data)
        {
            return (ProtocolType)BitConverter.ToUInt16(data, 0);
        }
    }
}
