using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _09PerformanceCounters
{
    class Program
    {
        static void Main(string[] args)
        {
            var counters = new CSharpDDCounters("09PerformanceCounters");

            while (!Console.KeyAvailable)
            {
                counters.BeginOperation();
                //Itt végezhetünk valami műveletet
                Thread.Sleep(238);
                counters.EndOperation();
            }
        }
    }
}
