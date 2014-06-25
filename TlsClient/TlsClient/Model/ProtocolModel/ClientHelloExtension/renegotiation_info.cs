using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TlsClient.Model.ProtocolModel.ClientHelloExtension
{
    public class renegotiation_info
    {
        private byte[] _type = new byte[2];
        public byte[] Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private byte[] _length = new byte[2];
        public byte[] Length
        {
            get { return _length; }
            set { _length = value; }
        }

        private byte _renegotiationinfoextensionlength;
        public byte Renegotiationinfoextensionlength
        {
            get { return _renegotiationinfoextensionlength; }
            set { _renegotiationinfoextensionlength = value; }
        }
    }
}
