using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetServer.TcpServer {
	class ByteQueue {
		private static readonly int _arrayLength = 4194304;
		private byte[] _byteArray = new byte[_arrayLength];

		private int _head = 0;
		private int _index = 0;
		private int _count = 0;
		public int Count {
			get {
				return _count;
			}
		}

		public ByteQueue() {
		
		}

		public byte Dequeue() {
			byte data = _byteArray[_head];
			_head++;
			_count--;
			return data;
		}

		public void Enqueue(byte data) {
			_byteArray[_index] = data;
			_index++;
			_count++;

		}
	}
}
