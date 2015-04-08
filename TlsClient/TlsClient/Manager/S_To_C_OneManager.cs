using RHClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TlsClient.Model;

namespace TlsClient.Manager
{
    public class S_To_C_OneManager
    {
        private S_To_C_One scOne;
        public S_To_C_OneManager()
        {
            if(scOne == null)
                scOne = new S_To_C_One();
        }

        public void AnalysePackage(byte[] s_cOneArray)
        {
            //取ServerHello中的随机数
            Array.ConstrainedCopy(s_cOneArray, 15, scOne.ServerHello.Random_bytes, 0, 28);
            Array.Copy(scOne.ServerHello.Random_bytes, App.SeverHelloAndClientHelloRandom, 28);
            Array.Copy(scOne.ServerHello.Random_bytes, 0, App.ClientHelloAndServerHelloRandom, 28, 28);
            //取ServerHello中的Length
            Array.ConstrainedCopy(s_cOneArray, 6, scOne.ServerHello.Length, 0, 3);
            string lengthHEX = JinZhiHelper.DecimalTo2HEX(scOne.ServerHello.Length[0])
                + JinZhiHelper.DecimalTo2HEX(scOne.ServerHello.Length[1])
                + JinZhiHelper.DecimalTo2HEX(scOne.ServerHello.Length[2]);
            scOne.ServerHello.LengthValue = Convert.ToInt32(lengthHEX, 16);
            //取Certificates中的公钥
            Array.ConstrainedCopy(s_cOneArray, 5 + 4 + scOne.ServerHello.LengthValue + 15, scOne.Certificate.Certificates, 0, 1376);
            X509Certificate2 cert = new X509Certificate2(scOne.Certificate.Certificates);
            scOne.Certificate.SubjectPublicKey = cert.GetPublicKey();
            App.PublicKey = cert.PublicKey;
        }
    }
}
