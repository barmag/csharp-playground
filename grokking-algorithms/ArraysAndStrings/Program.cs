using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndStrings
{
    class IsUnique
    {
        /// <summary>
        /// Tests if a the characters in a string are unique
        /// Brute force implementation
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static bool CharsInString_Brute(string word)
        {
            // assuming only english alpha characters are allowed
            var max_length = ('z' - 'a') + ('Z' - 'A');
            // if the length of the word is larger than the unique chars count
            // Then there must be a repetiotion ... exit
            if (word.Length > max_length) return false;

            var chars = word.ToCharArray();
            int currentIndex = 0;
            foreach(var c in chars)
            {
                for (int i = 0; i < chars.Length; i++)
                {
                    if (i != currentIndex && chars[i] == c)
                    {
                        return false;
                    }
                }
                currentIndex++;
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
        }
    }
}
