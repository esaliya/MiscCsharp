using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = 10;
            var values = new double[num];
            var indices = new int[num];
            for (var i = 0; i < num; ++i)
            {
                values[i] = i;
                indices[i] = num - i;
            }
            Console.WriteLine(string.Join(",", values));
            Array.Sort(indices,values);
            Console.WriteLine(string.Join(",", values));
            Console.Read();
        }
    }
}
