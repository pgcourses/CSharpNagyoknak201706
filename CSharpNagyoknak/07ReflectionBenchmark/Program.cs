using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07ReflectionBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            //SajatBenchmark();
            BenchmarkRunner.Run<BenchmarkReflectionVsNative>();
        }

        private static void SajatBenchmark()
        {
            var sw = new Stopwatch();

            var test = new BenchmarkReflectionVsNative();

            var loop = 1000000;

            sw.Restart();
            for (int i = 0; i < loop; i++)
            {
                var result = test.GetDateWithoutReflection();
            }
            Console.WriteLine("Without Reflection: {0}", sw.ElapsedMilliseconds);

            sw.Restart();
            for (int i = 0; i < loop; i++)
            {
                var result = test.GetDateWithReflection();
            }
            Console.WriteLine("With Reflection: {0}", sw.ElapsedMilliseconds);

            sw.Restart();
            for (int i = 0; i < loop; i++)
            {
                var result = test.GetDateWithReflectionFull();
            }
            Console.WriteLine("With Reflection and preparing: {0}", sw.ElapsedMilliseconds);

            //Without Reflection: 1502
            //With Reflection: 1652
            //With Reflection and preparing: 3438
        }
    }
}
