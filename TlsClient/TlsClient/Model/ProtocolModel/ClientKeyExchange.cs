using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TlsClient.Model.ProtocolModel
{
    public class ClientKeyExchange : Handshake
    {
        private byte[] _encryptedPreMasterlength = new byte[2];
        public byte[] EncryptedPreMasterlength
        {
            get { return _encryptedPreMasterlength; }
            set { _encryptedPreMasterlength = value; }
        }

        private byte[] _encryptedPreMaster = new byte[2];
        public byte[] EncryptedPreMaster
        {
            get { return _encryptedPreMaster; }
            set { _encryptedPreMaster = value; }
        }
    }
}
