using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndStrings
{
    class IsUnique
    {
        private static int GetMaxLength()
        {
            // assuming only english alpha characters are allowed
            var max_length = 'z' - 'A';
            return max_length;
        }
        private static bool IsOverMaxCharsetLength(string word)
        {
            var max_length = GetMaxLength();
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

        /// <summary>
        /// Implementation with a bool array for character occurunces
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static bool CharsInString_boolArray(string word)
        {
            if (IsOverMaxCharsetLength(word))
            {
                return false;
            }
            var max_length = GetMaxLength();
            var charOccurunce = new bool[max_length];

            foreach (var c in word)
            {
                var index = Convert.ToInt32(c) - Convert.ToInt32('A');
                if (charOccurunce[index])
                {
                    return false;
                }
                charOccurunce[index] = true;
            }
            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //RunIsUnique();
            //RunCheckPermtation();
            //RunPermIsPalindrome();
            RunOneAway();
        }

        private static void RunOneAway()
        {
            string s1 = "pale", s2 = "ple";
            bool oneAway = OneAway.Check(s1, s2);
            Console.WriteLine($"{s1}, {s2} should be true: {oneAway}");
            s1 = "pales"; s2 = "pale";
            Console.WriteLine($"{s1}, {s2} should be true: {oneAway}");
            s1 = "pale"; s2 = "bale";
            Console.WriteLine($"{s1}, {s2} should be true: {oneAway}");
            s1 = "pale"; s2 = "bake";
            Console.WriteLine($"{s1}, {s2} should be false");
        }

        private static void RunPermIsPalindrome()
        {
            string w1 = "Tact coa";
            string w2 = "not a palindrome";
            bool isPalindrome = PermIsPalindrom.Check(w1);
            Console.WriteLine($"{w1} should be palindrome: {isPalindrome}");
            isPalindrome = PermIsPalindrom.Check(w2);
            Console.WriteLine($"{w2} should return false: {isPalindrome}");
        }

        private static void RunCheckPermtation()
        {
            var permutationChecker = new PermutationChecker();

            string s1 = "hello", s2 = "lehlo";
            var isPerm = permutationChecker.Check(s1, s2);
            Console.WriteLine($"{s1} is a permutation of {s2}: {isPerm}");

            s1 = "random word";
            s2 = "randum word";
            isPerm = permutationChecker.Check(s1, s2);
            Console.WriteLine($"{s1} is a permutation of {s2}: {isPerm}");
        }

        private static void RunIsUnique()
        {
            var c1 = "Hello World!";
            var c2 = "Unique";

            Console.WriteLine("Hello world: {0}", IsUnique.CharsInString_Brute(c1));
            Console.WriteLine("unique: {0}", IsUnique.CharsInString_Brute(c2));

            Console.WriteLine("Hello world: {0}", IsUnique.CharsInString_sorting(c1));
            Console.WriteLine("unique: {0}", IsUnique.CharsInString_sorting(c2));

            Console.WriteLine("Hello world: {0}", IsUnique.CharsInString_boolArray(c1));
            Console.WriteLine("unique: {0}", IsUnique.CharsInString_boolArray(c2));
        }
    }
}
