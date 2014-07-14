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
            MemoryStream writeStream = requestManager.InitStream();
            byte[] c_sOneArray = writeStream.ToArray();
            
            string serverAddr = "221.176.31.177";
            int portNum = 443;
            TcpClient client = new TcpClient(serverAddr, portNum);
            NetworkStream stream = client.GetStream();
            stream.Write(c_sOneArray, 0, c_sOneArray.Length);

            MemoryStream contentStream = new MemoryStream();
            stream.ReadTimeout = 3 * 1000;
            byte[] readContent;
            int readLength = 0;
            do
            {
                readContent = new byte[1024];
                readLength = stream.Read(readContent, 0, readContent.Length);
                contentStream.Write(readContent, 0, readLength);
            }
            while (readLength == readContent.Length);
            byte[] s_cOneArray = contentStream.ToArray();

            S_To_C_OneManager receiveManager = new S_To_C_OneManager();
            receiveManager.AnalysePackage(s_cOneArray);

            ///http://tools.ietf.org/html/rfc5246#section-7.4.7
            ///http://www.ruanyifeng.com/blog/2014/02/ssl_tls.html
            Console.ReadKey();
        }
    }
}
