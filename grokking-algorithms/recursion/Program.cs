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
        static void Main(string[] args)
        {
            var elements = Enumerable.Range(0, 10).ToArray();
            var count = recursiveCont(elements);
            var result = sum(elements);
        }
    }
}
