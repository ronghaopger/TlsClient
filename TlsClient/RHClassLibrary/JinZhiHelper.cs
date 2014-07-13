using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RHClassLibrary
{
    public class JinZhiHelper
    {
        /// <summary>
        /// 0 => "00"   255 => "FF"
        /// </summary>
        /// <param name="decimalNum"></param>
        /// <returns></returns>
        public static string DecimalTo2HEX(int decimalNum)
        {
            if (decimalNum < 0 || decimalNum > 255)
                throw new ArgumentOutOfRangeException();
            return decimalNum.ToString("X");
        }
    }
}
