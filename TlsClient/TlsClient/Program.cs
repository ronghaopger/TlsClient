using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TlsClient.Model;

namespace TlsClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string serverAddr = "221.176.31.177";
            int portNum = 443;
            TcpClient client = new TcpClient(serverAddr, portNum);
            NetworkStream stream = client.GetStream(); 

            //构造Client第一次请求的数据包
            C_To_S_One csOne = new C_To_S_One();
            csOne.Base.ContentType = 22;
            csOne.Base.Version[0] = 3;
            csOne.Base.Version[1] = 1;
            //csOne.Base.Length
            csOne.ClientHello.HandshakeType = 1;
            //csOne.ClientHello.Length
            csOne.ClientHello.Version[0] = 3;
            csOne.ClientHello.Version[1] = 1;
            long seconds = (long)DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            csOne.ClientHello.Gmt_unix_time[3] = (byte)(seconds & 0xFF);
            csOne.ClientHello.Gmt_unix_time[2] = (byte)(seconds >> 8 & 0xFF);
            csOne.ClientHello.Gmt_unix_time[1] = (byte)(seconds >> 16 & 0xFF);
            csOne.ClientHello.Gmt_unix_time[0] = (byte)(seconds >> 24 & 0xFF);

            // add a newline to the text to send
            string sendData = "160301006701000063030152dcf458b5e71729b669ef75b11c5fec7e8433cd51454e5116bbca8a58b58332000018002f00350005000ac013c014c009c00a003200380013000401000022ff01000100000500050100000000000a0006000400170018000b0002010000230000";
            byte[] byteData = new byte[sendData.Length / 2];
            int[] hexDigits = new int[128];
            for (int i = '0'; i <= '9'; i++)
            {
                hexDigits[i] = i - '0';
            }
            for (int i = 'a'; i <= 'f'; i++)
            {
                hexDigits[i] = i - 'a' + 10;
            }

            for (int i = 0; i < sendData.Length; i += 2)
            {
                int c1 = hexDigits[sendData[i]];
                int c2 = hexDigits[sendData[i + 1]];
                byteData[i / 2] = (byte)((c1 << 4) | c2);
            }
            //DataWriter writer = new DataWriter(clientSocket.OutputStream);
            //writer.WriteBytes(byteData);
            //// Call StoreAsync method to store the data to a backing stream
            //await writer.StoreAsync();
            //// detach the stream and close it
            //writer.DetachStream();
            //writer.Dispose();

            //DataReader reader = new DataReader(clientSocket.InputStream);
            //reader.InputStreamOptions = InputStreamOptions.Partial;
            //var count = await reader.LoadAsync(255);
            //if (count > 0)
            //{
            //    byte[] serverHello = new byte[255];
            //    reader.ReadBytes(serverHello);
            //}
        }
    }
}
