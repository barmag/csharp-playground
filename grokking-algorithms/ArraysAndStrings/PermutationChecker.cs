using System;
using System.Collections.Generic;
using System.Linq;

namespace ArraysAndStrings
{
    internal class PermutationChecker
    {
        public PermutationChecker()
        {
            
        }

        /// <summary>
        /// Check if string src is a permutation of string dest
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dest"></param>
        /// <returns></returns>
        public bool Check(string src, string dest)
        {
            // calculate the sum of character int values of strings
            int sum1 = src.Sum(c => Convert.ToInt32(c));
            int sum2 = dest.Sum(c => Convert.ToInt32(c));
            return sum1 == sum2;
        }
    }
}