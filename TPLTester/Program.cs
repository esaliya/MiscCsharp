using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPLTester
{
    class Program
    {
        [DllImport("Kernel32.dll"), SuppressUnmanagedCodeSecurity]
        public static extern int GetCurrentProcessorNumber();

        public static void Main(string[] args)
        {
//            SimpleStencil();
            int colCount = int.Parse(args[0]); // default used to be 180
            int rowCount = int.Parse(args[1]); // default used to be 2000
            int colCount2 = int.Parse(args[2]); // default used to be 270
            MatMult.Multiply(colCount, rowCount, colCount2);
        }


        static void SimpleStencil()
        {
            const int giant = 100000;
            const int size = 8;
            var pops = new ParallelOptions {MaxDegreeOfParallelism = size};

            
            var a = new double[size+2];
            var random = new Random((int) System.DateTime.Now.Ticks);
            for (var i = 0; i < size+2; ++i)
            {
                a[i] = random.Next();
            }

            var b = new double[size];
            Parallel.For(0, size, pops, (threadNo) =>
            {
                
                b[threadNo] = (a[threadNo] + a[threadNo + 2])/2;
                var giantArray = new double[giant];
                var r= new Random((int)System.DateTime.Now.Ticks);
                for (var i = 0; i < giant; ++i)
                {
                    giantArray[i] = random.Next();
                }

                for (var i = 0; i < giant; ++i)
                {
                    giantArray[i] *= b[threadNo];
                }

                Console.WriteLine("task " + threadNo + " runs in thread " + Thread.CurrentThread.ManagedThreadId + " in processor " + GetCurrentProcessorNumber());
            });

            Console.WriteLine(string.Join(" ",a));
            Console.WriteLine(string.Join(" ",b));
            Console.Read();
        }
    }
}
