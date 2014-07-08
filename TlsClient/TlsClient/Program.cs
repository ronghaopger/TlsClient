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
            IManager manager = new C_To_S_OneManager();
            manager.InitPackage();
            MemoryStream stream = manager.InitStream();
            
            string serverAddr = "221.176.31.177";
            int portNum = 443;
            TcpClient client = new TcpClient(serverAddr, portNum);
            client.GetStream().Write(stream.ToArray(), 0, stream.ToArray().Length);
            Console.ReadKey();
        }
    }
}
