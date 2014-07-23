using System;
using System.Collections.Generic;
using System.IO;
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
            //csTwo.EncryptedHandshakeMessageBase.ContentType = 22;
            //csTwo.EncryptedHandshakeMessageBase.Version[0] = 3;
            //csTwo.EncryptedHandshakeMessageBase.Version[1] = 1;
            //csTwo.EncryptedHandshakeMessageBase.Length[0] = 0;
            //csTwo.EncryptedHandshakeMessageBase.Length[1] = 32;
            //App.HandshakeMessage = new byte[App.C_SOneArray.Length - 5 + App.S_COneArray.Length - 5];
            //Array.Copy(App.C_SOneArray, 5, App.HandshakeMessage, 0, App.C_SOneArray.Length - 5);
            //Array.Copy(App.S_COneArray, 5, App.HandshakeMessage, App.C_SOneArray.Length - 5, App.S_COneArray.Length - 5);

            //App.HandshakeMessage[App.C_SOneArray.Length - 5 + App.S_COneArray.Length - 5] = csTwo.ClientKeyExchange.HandshakeType;
            //Array.Copy(csTwo.ClientKeyExchange.Length, 0, App.HandshakeMessage, App.C_SOneArray.Length - 5 + App.S_COneArray.Length - 5 + 1, 3);
            //Array.Copy(csTwo.ClientKeyExchange.EncryptedPreMasterlength, 0, App.HandshakeMessage, App.C_SOneArray.Length - 5 + App.S_COneArray.Length - 5 + 4, 2);
            //Array.Copy(csTwo.ClientKeyExchange.EncryptedPreMaster, 0, App.HandshakeMessage, App.C_SOneArray.Length - 5 + App.S_COneArray.Length - 5 + 6, 128);

            //byte[] md5Hash = new MD5CryptoServiceProvider().ComputeHash(App.HandshakeMessage);
            //byte[] sha1Hash = new SHA1CryptoServiceProvider().ComputeHash(App.HandshakeMessage);
            //byte[] hash = new byte[md5Hash.Length + sha1Hash.Length];
            //md5Hash.CopyTo(hash, 0);
            //sha1Hash.CopyTo(hash, md5Hash.Length);
            //csTwo.EncryptedHandshakeMessage = hash;
        }

        public MemoryStream InitStream()
        {
            MemoryStream stream = new MemoryStream();
            stream.WriteByte(csTwo.ClientKeyExchangeBase.ContentType);
            stream.Write(csTwo.ClientKeyExchangeBase.Version, 0, 2);
            stream.Write(csTwo.ClientKeyExchangeBase.Length, 0, 2);
            stream.WriteByte(csTwo.ClientKeyExchange.HandshakeType);
            stream.Write(csTwo.ClientKeyExchange.Length, 0, 3);
            stream.Write(csTwo.ClientKeyExchange.EncryptedPreMasterlength, 0, 2);
            stream.Write(csTwo.ClientKeyExchange.EncryptedPreMaster, 0, 128);

            stream.WriteByte(csTwo.ChangeCipherSpecBase.ContentType);
            stream.Write(csTwo.ChangeCipherSpecBase.Version, 0, 2);
            stream.Write(csTwo.ChangeCipherSpecBase.Length, 0, 2);
            stream.WriteByte(csTwo.ChangeCipherSpecMessage);

            //stream.WriteByte(csTwo.EncryptedHandshakeMessageBase.ContentType);
            //stream.Write(csTwo.EncryptedHandshakeMessageBase.Version, 0, 2);
            //stream.Write(csTwo.EncryptedHandshakeMessageBase.Length, 0, 2);
            //stream.Write(csTwo.EncryptedHandshakeMessage, 0, 32);
            return stream;
        }
    }
}
