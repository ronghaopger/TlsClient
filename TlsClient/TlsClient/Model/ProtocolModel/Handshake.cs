using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TlsClient.Model.ProtocolModel
{
    public class Handshake
    {
        private string _handshakeType;
        public string HandshakeType
        {
            get { return _handshakeType; }
            set { _handshakeType = value; }
        }

        private string _length;
        public string Length
        {
            get { return _length; }
            set { _length = value; }
        }

        private string _version;
        public string Version
        {
            get { return _version; }
            set { _version = value; }
        }
    }
}
