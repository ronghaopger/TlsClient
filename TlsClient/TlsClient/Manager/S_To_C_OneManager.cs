﻿using System;
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
            //取ServerHello中的Length
            Array.ConstrainedCopy(s_cOneArray, 6, scOne.ServerHello.Length, 0, 3);
            //scOne.ServerHello.LengthValue = 
            //取Certificates中的公钥
            Array.ConstrainedCopy(s_cOneArray, 5 + 4, scOne.ServerHello.Random_bytes, 0, 28);
            //X509Certificate cert = new X509Certificate(
        }
    }
}