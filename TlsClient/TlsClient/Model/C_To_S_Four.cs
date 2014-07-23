using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TlsClient.Model.ProtocolModel;

namespace TlsClient.Model
{
    public class C_To_S_Four
    {
        private Base _encryptedHandshakeMessageBase = new Base();
        public Base EncryptedHandshakeMessageBase { get { return _encryptedHandshakeMessageBase; } }

        //private byte[] _encryptedHandshakeMessage = new byte[32];
        public byte[] EncryptedHandshakeMessage
        {
            get;
            set;
        }
    }
}
