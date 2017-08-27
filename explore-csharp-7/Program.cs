using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace explore_csharp_7
{
    class Program
    {
        //tuples in c# 7
        //tuple elements can be named (int cur, int prev)
        static (int, int) Fib(int i)
        {
            //return tuple literal
            if (i == 0) return (1, 0);

            var t = Fib(i - 1);
            return (t.Item1 + t.Item2, t.Item1);
        }

        //named tuple
        static (int curr, int prev) FibNamed(int i)
        {
            //the name is optional if specified in order
            if (i == 0) return (curr: 1, prev: 0);

            var t = FibNamed(i - 1);
            return (t.curr + t.prev, t.curr);
        }

        static int Fibonacci(int i)
        {
            return Fib(i).Item1;
        }
        static void Main(string[] args)
        {
            //tuples
            var fibresult = Fibonacci(20);
            Console.WriteLine($"Fibonacci of 20 is {fibresult}");

            //out variables
            GetCoordinates(out int x, out int y);
            Console.WriteLine($"Out varibles {x} and {y}");
        }

        private static void GetCoordinates(out int x, out int y)
        {
            x = 5;
            y = 10;
        }
    }
}
