using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TlsClient.Model;
using TlsClient.Utils;

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
            //生成Pre_Master_Secret
            byte[] _preMasterSecret = new byte[48];
            _preMasterSecret[0] = 3;
            _preMasterSecret[1] = 1;
            byte[] randomBytes = new byte[46];
            Random random = new Random();
            random.NextBytes(randomBytes);
            Array.Copy(randomBytes, 0, _preMasterSecret, 2, randomBytes.Length);
            //生成Master_Secret
            App.MasterSecret = Prf10.GenerateBytes(_preMasterSecret, "master secret", App.ClientHelloAndServerHelloRandom, 48);

            csTwo.ClientKeyExchangeBase.ContentType = 22;
            csTwo.ClientKeyExchangeBase.Version[0] = 3;
            csTwo.ClientKeyExchangeBase.Version[1] = 1;
            csTwo.ClientKeyExchangeBase.Length[0] = 1;
            csTwo.ClientKeyExchangeBase.Length[1] = 6;
            csTwo.ClientKeyExchange.HandshakeType = 16;
            csTwo.ClientKeyExchange.Length[0] = 0;
            csTwo.ClientKeyExchange.Length[1] = 1;
            csTwo.ClientKeyExchange.Length[2] = 2;
            csTwo.ClientKeyExchange.EncryptedPreMasterlength[0] = 1;
            csTwo.ClientKeyExchange.EncryptedPreMasterlength[1] = 0;
            var rsa = (RSACryptoServiceProvider)App.PublicKey.Key;
            csTwo.ClientKeyExchange.EncryptedPreMaster = rsa.Encrypt(_preMasterSecret, false);
            csTwo.ChangeCipherSpecBase.ContentType = 20;
            csTwo.ChangeCipherSpecBase.Version[0] = 3;
            csTwo.ChangeCipherSpecBase.Version[1] = 1;
            csTwo.ChangeCipherSpecBase.Length[0] = 0;
            csTwo.ChangeCipherSpecBase.Length[1] = 1;
            csTwo.ChangeCipherSpecMessage = 1;
            csTwo.EncryptedHandshakeMessageBase.ContentType = 22;
            csTwo.EncryptedHandshakeMessageBase.Version[0] = 3;
            csTwo.EncryptedHandshakeMessageBase.Version[1] = 1;


            App.HandshakeMessage = new byte[App.C_SOneArray.Length - 5 + App.S_COneArray.Length - 5 + 262];
            Array.Copy(App.C_SOneArray, 5, App.HandshakeMessage, 0, App.C_SOneArray.Length - 5);
            Array.Copy(App.S_COneArray, 5, App.HandshakeMessage, App.C_SOneArray.Length - 5, App.S_COneArray.Length - 5);

            App.HandshakeMessage[App.C_SOneArray.Length - 5 + App.S_COneArray.Length - 5 + 1] = csTwo.ClientKeyExchange.HandshakeType;
            Array.Copy(csTwo.ClientKeyExchange.Length, 0, App.HandshakeMessage, App.C_SOneArray.Length - 5 + App.S_COneArray.Length - 5 + 1, 3);
            Array.Copy(csTwo.ClientKeyExchange.EncryptedPreMasterlength, 0, App.HandshakeMessage, App.C_SOneArray.Length - 5 + App.S_COneArray.Length - 5 + 4, 2);
            Array.Copy(csTwo.ClientKeyExchange.EncryptedPreMaster, 0, App.HandshakeMessage, App.C_SOneArray.Length - 5 + App.S_COneArray.Length - 5 + 6, 256);

            byte[] md5Hash = new MD5CryptoServiceProvider().ComputeHash(App.HandshakeMessage);
            byte[] sha1Hash = new SHA1CryptoServiceProvider().ComputeHash(App.HandshakeMessage);
            byte[] hash = new byte[md5Hash.Length + sha1Hash.Length];
            md5Hash.CopyTo(hash, 0);
            sha1Hash.CopyTo(hash, md5Hash.Length);

            byte[] clientVerifyData = Prf10.GenerateBytes(App.MasterSecret, "client finished", hash, 12);
            var clientFinishedHeaderBytes = new byte[4];
            clientFinishedHeaderBytes[0] = 20;
            clientFinishedHeaderBytes[1] = 0;
            clientFinishedHeaderBytes[2] = 0;
            clientFinishedHeaderBytes[3] = 12;

            byte[] keyBlock = Prf10.GenerateBytes(App.MasterSecret, "key expansion", App.SeverHelloAndClientHelloRandom, 136);
            byte[] client_write_MAC_secret = new byte[20];
            byte[] client_write_key = new byte[32]; 
            Buffer.BlockCopy(keyBlock, 0, client_write_MAC_secret, 0, 20);
            Buffer.BlockCopy(keyBlock, 40, client_write_key, 0, 32);

            var clientFinishedHash = Hasher.ComputeTlsMD5Hmac(client_write_MAC_secret, 0x16, 0, ByteUtilities.ConcatBytes(clientFinishedHeaderBytes, clientVerifyData));
            var clientFinishedDecrypted = ByteUtilities.ConcatBytes(clientFinishedHeaderBytes, clientVerifyData, clientFinishedHash);
            Arc4 clientWriteArc4 = new Arc4(client_write_key);
            csTwo.EncryptedHandshakeMessage = clientWriteArc4.Encrypt(clientFinishedDecrypted);

            csTwo.EncryptedHandshakeMessageBase.Length[0] = 0;
            csTwo.EncryptedHandshakeMessageBase.Length[1] = (byte)csTwo.EncryptedHandshakeMessage.Length;
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
            stream.Write(csTwo.ClientKeyExchange.EncryptedPreMaster, 0, 256);

            stream.WriteByte(csTwo.ChangeCipherSpecBase.ContentType);
            stream.Write(csTwo.ChangeCipherSpecBase.Version, 0, 2);
            stream.Write(csTwo.ChangeCipherSpecBase.Length, 0, 2);
            stream.WriteByte(csTwo.ChangeCipherSpecMessage);

            stream.WriteByte(csTwo.EncryptedHandshakeMessageBase.ContentType);
            stream.Write(csTwo.EncryptedHandshakeMessageBase.Version, 0, 2);
            stream.Write(csTwo.EncryptedHandshakeMessageBase.Length, 0, 2);
            stream.Write(csTwo.EncryptedHandshakeMessage, 0, csTwo.EncryptedHandshakeMessage.Length);
            return stream;
        }
    }
}
