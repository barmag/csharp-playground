using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chapter_1
{
    class Program
    {
        //does a binary search in an integer array
        //returns index of fpund element, -1 if not found
        static int binarySearch(int[] array, int qry)
        {
            int low = 0, high = array.Length - 1, mid = 0;
            while (low <= high)
            {
                mid = (low + high) / 2;
                int guess = array[mid];
                if (guess == qry)
                {
                    return mid;
                }
                else if (guess > qry)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            
            return -1;
        }
        static void Main(string[] args)
        {
            var arr = Enumerable.Range(1, 1024).ToArray();
            var result = binarySearch(arr, 80);
            result = binarySearch( arr, -1);
            result = binarySearch(arr, 300);
            result = binarySearch(arr, 3000);

            //how many variance a word ideal have
            var a = countAnagrams("ab");
            var a2 = countAnagrams("abc");
            var a3 = countAnagrams("abcd");
            var a4 = countAnagrams("IDEAL");
        }

        static int countAnagrams(string s)
        {
            Dictionary<string, int> variances = new Dictionary<string, int>();
            variances.Add(s, 0);
            
            for (int i = 0; i < s.Length; i++)
            {
                var chars = s.ToCharArray();
                var toSwitch = chars[i];
                for (int j = 0; j < s.Length; j++)
                {
                    var tmp = chars[j];
                    chars[j] = chars[i];
                    chars[i] = tmp;
                    string ns = string.Join("", chars);
                    if (!variances.ContainsKey(ns))
                        variances.Add(ns, 0);
                }
            }

            return variances.Count;
        }
    }
}
