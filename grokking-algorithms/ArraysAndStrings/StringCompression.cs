﻿using System;
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
            var buffer = new StringBuilder();

            for (int index = 0; index < s.Length; index++)
            {
                if (index+1 < s.Length)
                {
                    if (s[index] != s[index+1])
                    {
                        buffer.Append(s[index]);
                    }
                    else
                    {
                        index++;
                    }
                }
                else
                {
                    if (index == s.Length-1)
                    {
                        buffer.Append(s[index]);
                    }
                }
            }
            
            return buffer.ToString();
        }
    }
}