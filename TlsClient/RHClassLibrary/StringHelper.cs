using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RHClassLibrary
{
    public class StringHelper
    {
       
    }

    public static class StringExtesion
    {
        /// <summary>
        /// Gets the ASCII byte represetnation of <paramref name="s"/>.
        /// </summary>
        /// <param name="s">The string to get the ASCII byte representation of.</param>
        /// <returns>The ASCII byte representation of <paramref name="s"/>.</returns>
        public static byte[] ToAsciiBytes(this string s)
        {
            return Encoding.ASCII.GetBytes(s);
        }
    }
}
