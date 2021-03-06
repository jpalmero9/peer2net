//
// - ConnectionBundle.cs
// 
// Author:
//     Lucas Ontivero <lucasontivero@gmail.com>
// 
// Copyright 2013 Lucas E. Ontivero
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//  http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// <summary></summary>

using System;
using System.Net;
using Peer2Net.BufferManager;
using Peer2Net.Progress;

namespace Peer2Net
{
    public class Peer
    {
        private readonly IConnection _connection;
        private readonly PeerStat _statistics;
        private readonly IBandwidthController _receiveBandwidthController;
        private readonly IBandwidthController _sendBandwidthController;
        private readonly SpeedWatcher _sendSpeedWatcher;
        private readonly SpeedWatcher _receiveSpeedWatcher;
        private readonly Uri _uri;

        internal IConnection Connection
        {
            get { return _connection; }
        }

        public Uri Uri
        {
            get { return _uri; }
        }

        public IPEndPoint EndPoint
        {
            get { return _connection.Endpoint; }
        }

        public PeerStat Statistics
        {
            get { return _statistics; }
        }

        internal IBandwidthController ReceiveBandwidthController
        {
            get { return _receiveBandwidthController; }
        }

        internal IBandwidthController SendBandwidthController
        {
            get { return _sendBandwidthController; }
        }

        public SpeedWatcher SendSpeedWatcher
        {
            get { return _sendSpeedWatcher; }
        }

        public SpeedWatcher ReceiveSpeedWatcher
        {
            get { return _receiveSpeedWatcher; }
        }

        internal Peer(IConnection connection)
        {
            _connection = connection;
            _sendSpeedWatcher = new SpeedWatcher();
            _receiveSpeedWatcher = new SpeedWatcher();
            _receiveBandwidthController = new UnlimitedBandwidthController();
            _sendBandwidthController = new UnlimitedBandwidthController();
            _statistics = new PeerStat();
            _uri = new Uri("tcp://" + EndPoint.Address + ':' + EndPoint.Port);
        }
    }
}