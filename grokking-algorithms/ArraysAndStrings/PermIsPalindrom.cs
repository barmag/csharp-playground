using System.Collections.Generic;

namespace ArraysAndStrings
{
    internal class PermIsPalindrom
    {
        /// <summary>
        /// Check if a string permutation is a plaindrome
        /// Make sure that the char occurance is odd except for at most one
        /// </summary>
        /// <param name="w1"></param>
        /// <returns></returns>
        internal static bool Check(string w1)
        {
            w1 = w1.ToLower();
            //use a hashset as a cache and remove prev occurances
            HashSet<char> charsCache = new HashSet<char>();
            foreach (char c in w1)
            {
                if (charsCache.Contains(c))
                {
                    charsCache.Remove(c);
                }
                else if(!char.IsPunctuation(c))
                {
                    charsCache.Add(c);
                }
            }
            charsCache.Remove(' ');
            if (charsCache.Count > 1)
            {
                return false;
            }
            return true;
        }
    }
}
