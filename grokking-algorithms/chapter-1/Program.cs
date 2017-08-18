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
        }
    }
}
