using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RHClassLibrary
{
    public class Converts
    {
        /// <summary>
        /// List<T[]> To T[]
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listArray"></param>
        /// <returns></returns>
        public static T[] ListToByteArray<T>(List<T[]> listArray)
        {
            int arrayLength = 0;
            for (int i = 0; i < listArray.Count; i++)
            {
                arrayLength += listArray[i].Length;
            }
            T[] array = new T[arrayLength];
            int arrayIndex = 0;
            for (int i = 0; i < listArray.Count; i++)
            {
                for (int j = 0; j < listArray[i].Length; j++)
                {
                    array[arrayIndex++] = listArray[i][j];
                }
            }
            return array;
        }
    }
}
