using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        internal static string SuperReduceString(string s)
        {
            var result = new Stack<char>(); 

            for (int i = 0; i < s.Length; i++)
            {
                char current = s[i];
                if (result.Count != 0 && result.Peek() == current)
                {
                    result.Pop();
                }
                else
                {
                    result.Push(current);
                }
            }
            if (result.Count == 0)
            {
                return "Empty String";
            }
            return string.Join("", result.ToArray().Reverse());
        }
    }
}