﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndStrings
{
    class IsUnique
    {
        private static bool IsOverMaxCharsetLength(string word)
        {
            // assuming only english alpha characters are allowed
            var max_length = ('z' - 'a') + ('Z' - 'A');
            // if the length of the word is larger than the unique chars count
            // Then there must be a repetiotion ... exit
            if (word.Length > max_length || word.Length < 2)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Tests if a the characters in a string are unique
        /// Brute force implementation
        /// O(n squared)
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static bool CharsInString_Brute(string word)
        {
            if (IsOverMaxCharsetLength(word)) return false;

            //var chars = word.ToCharArray();
            int currentIndex = 0;
            foreach(var c in word)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if (i != currentIndex && word[i] == c)
                    {
                        return false;
                    }
                }
                currentIndex++;
            }
            return true;
        }

        /// <summary>
        /// Tests if characters in string is unique
        /// Implementation with sorting o (n log(n))
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static bool CharsInString_sorting(string word)
        {
            if (IsOverMaxCharsetLength(word)) return false;

            var chars = word.OrderBy(c => c).ToArray();
            for (int i = 0; i < chars.Length-1; i++)
            {
                if (chars[i] == chars[i+1])
                {
                    return false;
                }
            }
            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var c1 = "Hello World!";
            var c2 = "Unique";

            Console.WriteLine("Hello world: {0}", IsUnique.CharsInString_Brute(c1));
            Console.WriteLine("unique: {0}", IsUnique.CharsInString_Brute(c2));

            Console.WriteLine("Hello world: {0}", IsUnique.CharsInString_sorting(c1));
            Console.WriteLine("unique: {0}", IsUnique.CharsInString_sorting(c2));
        }
    }
}
