using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TlsClient.Utils
{
    public static class ByteUtilities
    {
        /// <summary>
        /// Concatenates byte arrays into a single byte array.
        /// </summary>
        /// <param name="byteArrays">An array containing all the byte arrays to combine.</param>
        /// <returns>A combined array of all of the individual arrays in <paramref name="byteArrays"/>.</returns>
        public static byte[] ConcatBytes(params byte[][] byteArrays)
        {
            using (var ms = new MemoryStream())
            {
                foreach (byte[] currentArray in byteArrays)
                {
                    ms.Write(currentArray, 0, currentArray.Length);
                }

                return ms.ToArray();
            }
        }
    }
}
