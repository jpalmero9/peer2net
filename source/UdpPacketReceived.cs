﻿using System.Net;

namespace Peer2Net
{
    public class UdpPacketReceivedEventArgs : System.EventArgs
    {
		private readonly IPEndPoint _endpoint;
        private readonly byte[] _data;

        public UdpPacketReceivedEventArgs(IPEndPoint endpoint, byte[] data)
        {
			_endpoint = endpoint;
            _data = data;
        }

		public IPEndPoint EndPoint
		{
			get { return _endpoint;	}
		}

        public byte[] Data
        {
            get { return _data; }
        }
    }
}
