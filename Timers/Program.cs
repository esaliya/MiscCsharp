using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using HPC.Utilities;

namespace Timers
{
    class Program
    {
        static void Main(string[] args)
        {
            // High performance timer
            var hiPerfTimer = new HiPerfTimer();
            hiPerfTimer.Start();
            Thread.Sleep(237);
            hiPerfTimer.Stop();
            Console.WriteLine("HiPerf Time: " + hiPerfTimer.Duration);
            hiPerfTimer.Start();
            Thread.Sleep(243);
            hiPerfTimer.Stop();
            Console.WriteLine("HiPerf Time: " + hiPerfTimer.Duration);

            Console.WriteLine("Stopwatch is hiperf " + Stopwatch.IsHighResolution);
            Console.WriteLine("Stopwatch freq (tics/sec) " + Stopwatch.Frequency);
            Console.WriteLine("Stopwatch 1/freq (ms/tick) " + 1000.0/Stopwatch.Frequency);
            var stopWatch = Stopwatch.StartNew();
            Thread.Sleep(237);
            stopWatch.Stop();
            Console.WriteLine("Stopwatch Time: " + stopWatch.Elapsed);
            Console.WriteLine("Stopwatch Time by freq (ms): " + (((double)(stopWatch.ElapsedTicks)) / Stopwatch.Frequency) * 1000 );
            stopWatch.Restart();
            Thread.Sleep(243);
            stopWatch.Stop();
            Console.WriteLine("Stopwatch Time: " + stopWatch.Elapsed);
            Console.WriteLine("Stopwatch Time by freq (ms): " + (((double)(stopWatch.ElapsedTicks)) / Stopwatch.Frequency) * 1000);

            Console.Read();

        }

        static void BusyWork1()
        {
            var x = 10000;
            long y = 1;
            for (var i = 0; i < x; i++)
            {
                y *= 10;
            }
            Console.WriteLine("busy work completed y=" + y);
        }

        static void BusyWork2()
        {
            var n = 10000;
            long z = 1;
            for (var i = 0; i < n; i++)
            {
                z *= 10;
            }
            Console.WriteLine("busy work completed z=" + z);
        }
    }
}
