using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TlsClient.Model.ProtocolModel
{
    public class ServerHello
    {
        private byte[] _length = new byte[3];
        public byte[] Length
        {
            get { return _length; }
            set { _length = value; }
        }
        public int LengthValue
        {
            get;
            set;
        }

        private byte[] _random_bytes = new byte[28];
        public byte[] Random_bytes
        {
            get { return _random_bytes; }
            set { _random_bytes = value; }
        }
    }
}
