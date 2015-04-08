using RHClassLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TlsClient.Manager;
using TlsClient.Model;

namespace TlsClient
{
    class Program
    {
        static void Main(string[] args)
        {
            IRequestManager requestManager = new C_To_S_OneManager();
            requestManager.InitPackage();
            App.C_SOneArray = requestManager.InitStream().ToArray();
            
            string serverAddr = "61.135.185.140";
            int portNum = 443;
            TcpClient client = new TcpClient(serverAddr, portNum);
            NetworkStream stream = client.GetStream();
            stream.Write(App.C_SOneArray, 0, App.C_SOneArray.Length);

            MemoryStream contentStream = new MemoryStream();
            stream.ReadTimeout = 3 * 1000;
            byte[] readContent;
            int readLength = 0;
            do
            {
                readContent = new byte[10240];
                readLength = stream.Read(readContent, 0, readContent.Length);
                contentStream.Write(readContent, 0, readLength);
            }
            while (readLength == readContent.Length);
            App.S_COneArray = contentStream.ToArray();

            S_To_C_OneManager receiveManager = new S_To_C_OneManager();
            receiveManager.AnalysePackage(App.S_COneArray);

            requestManager = new C_To_S_TwoManager();
            requestManager.InitPackage();
            App.C_STwoArray = requestManager.InitStream().ToArray();
            stream.Write(App.C_STwoArray, 0, App.C_STwoArray.Length);


            //http://blog.jobbole.com/48369/


            ///http://tools.ietf.org/html/rfc5246#section-7.4.7
            ///http://www.ruanyifeng.com/blog/2014/02/ssl_tls.html
            Console.ReadKey();
        }
    }
}
