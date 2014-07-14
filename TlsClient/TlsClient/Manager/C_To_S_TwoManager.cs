using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TlsClient.Model;

namespace TlsClient.Manager
{
    public class C_To_S_TwoManager : IRequestManager
    {
         private C_To_S_Two csTwo;
         public C_To_S_TwoManager()
        {
            if(csTwo == null)
                csTwo = new C_To_S_Two();
        }

        public void InitPackage()
        {
            csTwo.ClientKeyExchangeBase.ContentType = 22;
            csTwo.ClientKeyExchangeBase.Version[0] = 3;
            csTwo.ClientKeyExchangeBase.Version[1] = 1;
            csTwo.ClientKeyExchangeBase.Length[0] = 0;
            csTwo.ClientKeyExchangeBase.Length[1] = 134;
            csTwo.ClientKeyExchange.HandshakeType = 16;
            csTwo.ClientKeyExchange.Length[0] = 0;
            csTwo.ClientKeyExchange.Length[1] = 0;
            csTwo.ClientKeyExchange.Length[2] = 130;
            csTwo.ClientKeyExchange.EncryptedPreMasterlength[0] = 0;
            csTwo.ClientKeyExchange.EncryptedPreMasterlength[1] = 128;
            byte[] _preMasterSecret = new byte[48];
            Random random = new Random();
            random.NextBytes(_preMasterSecret);
            csTwo.ClientKeyExchange.EncryptedPreMaster = new RSACryptoServiceProvider().Encrypt(_preMasterSecret, false);
            csTwo.ChangeCipherSpecBase.ContentType = 20;
            csTwo.ChangeCipherSpecBase.Version[0] = 3;
            csTwo.ChangeCipherSpecBase.Version[1] = 1;
            csTwo.ChangeCipherSpecBase.Length[0] = 0;
            csTwo.ChangeCipherSpecBase.Length[1] = 1;
            csTwo.ChangeCipherSpecMessage = 1;
            csTwo.EncryptedHandshakeMessageBase.ContentType = 22;
            csTwo.EncryptedHandshakeMessageBase.Version[0] = 3;
            csTwo.EncryptedHandshakeMessageBase.Version[1] = 1;
            //csTwo.EncryptedHandshakeMessageBase.Length[0] = 1;
            //csTwo.EncryptedHandshakeMessageBase.Length[1] = 1;
            //csTwo.EncryptedHandshakeMessage = ;

        }

        public System.IO.MemoryStream InitStream()
        {
            throw new NotImplementedException();
        }
    }
}
