﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recursion
{
    class Program
    {
        static int sum(int[] elements)
        {
            if (elements.Length == 0)
                return 0;
            if (elements.Length == 1)
                return elements[0];

            return elements[0] + sum(elements.Skip(1).Take(elements.Length - 1).ToArray());
        }

        static int recursiveCont(int[] source)
        {
            if (source .Length == 0)
            {
                return 0;
            }
            var count = 1 + recursiveCont(source.Skip(1).Take(source.Length - 1).ToArray());
            return count;
        }

        static int maxRecursive(int[] arr)
        {
            if (arr.Length == 1)
                return arr[0];
            if (arr.Length == 2)
                return arr[0] > arr[1] ? arr[0] : arr[1];
            var tempMax = maxRecursive(arr.Skip(1).Take(arr.Length - 1).ToArray());
            var max = arr[0] > tempMax ? arr[0] : tempMax;
            return max;
        }

        static int binarySearchRecursive(int qry, int[] array)
        {
            if (array.Length == 0)
                return -1;
            if (array.Length == 1)
                return array[0] == qry ? 0 : -1;
            if(array.Length == 2)
            {
                if (array[0] == qry) return 0;
                if (array[1] == qry) return 1;
                return -1;
            }

            var mid = array.Length / 2;
            var midElement = array[mid];
            if (midElement == qry)
                return mid;
            if(midElement > qry)
            {
                return binarySearchRecursive(qry, array.Take(mid).ToArray());
            }

            var index = binarySearchRecursive(qry, array.Skip(mid).ToArray());
            if (index == -1) return -1;
            return mid + index;
        }
        static void Main(string[] args)
        {
            var elements = Enumerable.Range(0, 10).ToArray();
            var count = recursiveCont(elements);
            var max = maxRecursive(elements);
            var s1 = binarySearchRecursive(9, elements);
            var s2 = binarySearchRecursive(200, elements);
            var s3 = binarySearchRecursive(0, elements);
            var s5 = binarySearchRecursive(1, elements);
            var s4 = binarySearchRecursive(-5, elements);
            var result = sum(elements);
        }
    }
}
