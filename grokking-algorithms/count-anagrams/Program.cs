using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace count_anagrams
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "cde";
            string b = "abc";

            int MAX_CHARS = 26;

            int[] a1 = new int[MAX_CHARS];
            int[] b1 = new int[MAX_CHARS];

            calculateCharCount(a, a1);
            calculateCharCount(b, b1);
            var diff = calcDifference(a1, b1);
        }

        private static int calcDifference(int[] a, int[] b)
        {
            var result = 0;
            for (int i = 0; i < a.Length; i++)
            {
                result += Math.Abs(a[i] - b[i]);
            }
            return result;
        }

        private static void calculateCharCount(string a, int[] a1)
        {
            for (int i = 0; i < a.Length; i++)
            {
                char c = a[i];
                var index = (int)c - (int)'a';
                a1[index]++;
            }
        }
    }
}
