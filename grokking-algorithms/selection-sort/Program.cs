using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selection_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();

            var array = Enumerable.Range(0, 100).OrderBy(x => rand.Next()).ToArray();
            var strted = selectionSort(array);
        }

        static int[] selectionSort(int[] source)
        {
            //var result = new int[source.Length];
            var min_index = 0;
            for (int i = 0; i < source.Length; i++)
            {
                min_index = i;
                for (int x = i; x < source.Length; x++)
                {
                    if (source[min_index] > source[x])
                    {
                        min_index = x;
                    }
                }
                int temp = source[i];
                source[i] = source[min_index];
                source[min_index] = temp;
            }

            return source;
        }
    }
}
