using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TlsClient.Model.ProtocolModel
{
    public class Certificate
    {
        private byte[] _certificates = new byte[1376];
        public byte[] Certificates
        {
            get { return _certificates; }
            set { _certificates = value; }
        }

        //private byte[] _subjectPublicKey = new byte[140];
        public byte[] SubjectPublicKey
        {
            get;
            set;
        }
    }
}
