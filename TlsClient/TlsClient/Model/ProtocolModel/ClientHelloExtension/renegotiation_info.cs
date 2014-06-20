using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TlsClient.Model.ProtocolModel.ClientHelloExtension
{
    public class renegotiation_info
    {
        private string _type;
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private string _length;
        public string Length
        {
            get { return _length; }
            set { _length = value; }
        }

        private string _renegotiationinfoextensionlength;
        public string Renegotiationinfoextensionlength
        {
            get { return _renegotiationinfoextensionlength; }
            set { _renegotiationinfoextensionlength = value; }
        }
    }
}
