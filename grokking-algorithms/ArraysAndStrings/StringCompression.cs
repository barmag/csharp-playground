using System;

namespace ArraysAndStrings
{
    internal class StringCompression
    {
        /// <summary>
        /// Simple compression of a string
        /// if a character is repeated, replace repeated char with number of repetitions
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        internal static string Compress(string v)
        {
            string temp = "";
            int counter = 1;
            char current = ' ';
            foreach (var c in v)
            {
                if(current != c)
                {
                    temp += counter != 1 ? counter.ToString() : "";
                    temp += c;
                    counter = 1;
                    current = c;
                }
                else
                {
                    counter++;
                }
            }
            temp += counter != 1 ? counter.ToString() : "";
            return temp;
        }
    }
}