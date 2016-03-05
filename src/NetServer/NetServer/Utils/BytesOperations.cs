using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetServer.Utils
{
    public static class BytesOperations
    {
        public static byte[] BytesUnion(byte[] oldBytes, byte[] newBytes)
        {
            int iLen = 0;
            if (newBytes != null)
            {//要添加到原数组中的字节如果不为空
                if (oldBytes != null)
                {
                    iLen = oldBytes.Length;
                }
                byte[] unionbyte = new byte[newBytes.Length + iLen];
                if (oldBytes != null)
                {
                    oldBytes.CopyTo(unionbyte, 0);
                }
                newBytes.CopyTo(unionbyte, iLen);
                return unionbyte;
            }
            else
            {
                return oldBytes;
            }
        }
    }
}
