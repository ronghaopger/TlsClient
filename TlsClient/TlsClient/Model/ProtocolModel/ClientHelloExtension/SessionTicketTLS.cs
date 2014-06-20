using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TlsClient.Model.ProtocolModel.ClientHelloExtension
{
    public class SessionTicketTLS
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

        private string _data;
        public string Data
        {
            get { return _data; }
            set { _data = value; }
        }
    }
}
