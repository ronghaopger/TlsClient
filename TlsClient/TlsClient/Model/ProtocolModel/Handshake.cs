using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TlsClient.Model.ProtocolModel
{
    public class Handshake
    {
        private byte _handshakeType;
        public byte HandshakeType
        {
            get { return _handshakeType; }
            set { _handshakeType = value; }
        }

        private byte[] _length = new byte[3];
        public byte[] Length
        {
            get { return _length; }
            set { _length = value; }
        }

        private byte[] _version = new byte[2];
        public byte[] Version
        {
            get { return _version; }
            set { _version = value; }
        }
    }
}
