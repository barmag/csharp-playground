using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ransome_note
{
    class Program
    {
        static void Main(string[] args)
        {

            //var sa = "give me one grand today night";
            //var sb = "give one grand today";

            //var s2 = "two times three is not four";
            //var s3 = "two times two is four";

            //bool result = isNoteContained(s2.Split(' '), s3.Split(' '));
            ////result = isNoteContained(s3, s2);
            //if (result)
            //{
            //    Console.WriteLine("Yes");
            //}
            //else
            //{
            //    Console.WriteLine("No");
            //}

            oddNumbers(2, 5);
        }

        static int[] oddNumbers(int l, int r)
        {
            var counter = l < r ? l : r;
            counter = counter % 2 == 0 ? counter : counter++;
            int[] result = new int[Math.Abs(r - l) / 2];
            int index = 0;
            while (counter < (l < r ? r : l))
            {
                result[index] = counter;
                counter += 2;
                Console.WriteLine(counter);
                index++;
            }
            return result;
        }

        static string findNumber(int[] arr, int k)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == k)
                {
                    return "YES";
                }
            }
            return "NO";
        }

        private static bool isNoteContained(string[] magazine, string[] ransome)
        {
            var allWords = magazine;
            Dictionary<string, int> wordsDictionary = new Dictionary<string, int>();
            foreach (var item in allWords)
            {
                if (wordsDictionary.ContainsKey(item))
                {
                    wordsDictionary[item]++;
                }
                else
                {
                    wordsDictionary[item] = 1;
                }
            }
            bool result = true;
            var ransomWords = ransome;
            foreach (var item in ransomWords)
            {
                if (wordsDictionary.ContainsKey(item) && wordsDictionary[item] > 0)
                {
                    result = result && true;
                    wordsDictionary[item]--;
                }
                else
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
    }
}
