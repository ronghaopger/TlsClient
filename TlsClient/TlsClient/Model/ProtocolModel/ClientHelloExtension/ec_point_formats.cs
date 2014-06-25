using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TlsClient.Model.ProtocolModel.ClientHelloExtension
{
    public class ec_point_formats
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

        private byte _eCpointformatsLength;
        public byte ECpointformatsLength
        {
            get { return _eCpointformatsLength; }
            set { _eCpointformatsLength = value; }
        }

        private byte _eCpointformat;
        public byte ECpointformat
        {
            get { return _eCpointformat; }
            set { _eCpointformat = value; }
        }
    }
}
