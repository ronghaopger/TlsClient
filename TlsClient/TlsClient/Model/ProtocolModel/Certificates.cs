using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TlsClient.Model.ProtocolModel
{
    public class Certificates
    {
        private byte[] _subjectPublicKey = new byte[1412];
        public byte[] SubjectPublicKey
        {
            get { return _subjectPublicKey; }
            set { _subjectPublicKey = value; }
        }
    }
}
