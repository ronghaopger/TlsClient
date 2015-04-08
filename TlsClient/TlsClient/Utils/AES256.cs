using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TlsClient.Utils
{
    public static class AES256
    {
        public static byte[] EncryptMessage(byte[] text, byte[] key)
        {
        RijndaelManaged aes = new RijndaelManaged();
         aes.KeySize = 256; 
         aes.BlockSize = 256;
         aes.Padding = PaddingMode.Zeros;
         aes.Mode = CipherMode.CBC;

         aes.Key = key;
         aes.GenerateIV();

        string IV = ("-[--IV-[-" + Encoding.Default.GetString(aes.IV));

        ICryptoTransform AESEncrypt = aes.CreateEncryptor(aes.Key, aes.IV);
        byte[] buffer = text;

        return
        Encoding.Default.GetBytes(Encoding.Default.GetString(AESEncrypt.TransformFinalBlock(buffer, 0, buffer.Length)) + IV);

        }

    }
}
