using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TlsClient.Model.ProtocolModel
{
    public class Base
    {
        private byte _contentType;
        public byte ContentType
        {
            get { return _contentType; }
            set { _contentType = value; }
        }

        private byte[] _version = new byte[2];
        public byte[] Version
        {
            get { return _version; }
            set { _version = value; }
        }

        private byte[]  _length = new byte[2];
        public byte[] Length
        {
            get { return _length; }
            set { _length = value; }
        }
    }
}
