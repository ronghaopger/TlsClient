using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TlsClient
{
    public class App
    {
        public static PublicKey PublicKey
        {
            get;
            set;
        }
        public static byte[] MasterSecret
        {
            get;
            set;
        }

        public static byte[] SeverHelloAndClientHelloRandom
        {
            get;
            set;
        }
        public static byte[] ClientHelloAndServerHelloRandom
        {
            get;
            set;
        }

        public static byte[] HandshakeMessage
        {
            get;
            set;
        }

        private static byte[] c_sOneArray;
        public static byte[] C_SOneArray
        {
            get { return c_sOneArray; }
            set { c_sOneArray = value; }
        }

        private static byte[] s_cOneArray;
        public static byte[] S_COneArray
        {
            get { return s_cOneArray; }
            set { s_cOneArray = value; }
        }

        private static byte[] c_sTwoArray;
        public static byte[] C_STwoArray
        {
            get { return c_sTwoArray; }
            set { c_sTwoArray = value; }
        }
    }
}
