﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TlsClient.Model.ProtocolModel;

namespace TlsClient.Model
{
    public class C_To_S_Two
    {
        private Base _clientKeyExchangeBase = new Base();
        public Base ClientKeyExchangeBase { get { return _clientKeyExchangeBase; } }

        private ClientKeyExchange _clientKeyExchange = new ClientKeyExchange();
        public ClientKeyExchange ClientKeyExchange { get { return _clientKeyExchange; } }

        private Base _changeCipherSpecBase = new Base();
        public Base ChangeCipherSpecBase { get { return _changeCipherSpecBase; } }

        private byte[] _changeCipherSpecMessage = new byte[1];
        public byte[] ChangeCipherSpecMessage
        {
            get { return _changeCipherSpecMessage; }
            set { _changeCipherSpecMessage = value; }
        }

        private Base _encryptedHandshakeMessageBase = new Base();
        public Base EncryptedHandshakeMessageBase { get { return _encryptedHandshakeMessageBase; } }

        private byte[] _encryptedHandshakeMessage = new byte[32];
        public byte[] EncryptedHandshakeMessage
        {
            get { return _encryptedHandshakeMessage; }
            set { _encryptedHandshakeMessage = value; }
        }
    }
}
