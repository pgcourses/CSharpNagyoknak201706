using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace _09PerformanceCounters
{
    public class CSharpDDCounters
    {
        private string appName;
        private readonly PerformanceCounter avgTimeOfOp;
        private readonly PerformanceCounter avgTimeOfOpBase;
        private readonly PerformanceCounter noOfOp;
        private readonly PerformanceCounter noOfOpPerSec;
        private long begin, end;

        public CSharpDDCounters(string appName)
        {
            this.appName = appName;
            //ellenőrizzük, hogy léteznek-e a teljesítménymutatók
            CheckCountersExists(appName);
            //csatlakozunk a mutatókhoz

            noOfOp = new PerformanceCounter(appName, MagicValues.NoOfOp, false);
            noOfOpPerSec = new PerformanceCounter(appName, MagicValues.NoOfOpPerSec, false);
            avgTimeOfOp = new PerformanceCounter(appName, MagicValues.AvgTimeOfOp, false);
            avgTimeOfOpBase = new PerformanceCounter(appName, MagicValues.AvgTimeOfOpBase, false);

        }

        [DllImport("Kernel32.dll")]
        private static extern void QueryPerformanceCounter(ref long tick);

        public void BeginOperation()
        {
            QueryPerformanceCounter(ref begin);
        }

        public void EndOperation()
        {
            QueryPerformanceCounter(ref end);
            var ticks = end - begin;
            noOfOp.Increment();
            noOfOpPerSec.Increment();
            avgTimeOfOpBase.Increment();
            avgTimeOfOp.IncrementBy(ticks);
        }

        /// <summary>
        /// A teljesítménymutatók ellenőrzése és létrehozása, ha szükséges
        /// </summary>
        /// <param name="appName"></param>
        private static void CheckCountersExists(string appName)
        {
            if (!PerformanceCounterCategory.Exists(appName))
            { //ha még nincs a gépen ilyen, akkor most létrehozzuk 

                //Kell egy gyűjtemény a teljesítménymutatókból.
                var counters = new CounterCreationDataCollection();

                //Feltöltjük a gyűjteményt
                var counter = new CounterCreationData();
                counter.CounterName = MagicValues.NoOfOp;
                counter.CounterHelp = "Az elvégzett összes művelet száma";
                counter.CounterType = PerformanceCounterType.NumberOfItems32;
                counters.Add(counter);

                counter = new CounterCreationData();
                counter.CounterName = MagicValues.NoOfOpPerSec;
                counter.CounterHelp = "A műveletek száma másodpercenként";
                counter.CounterType = PerformanceCounterType.RateOfCountsPerSecond32;
                counters.Add(counter);

                counter = new CounterCreationData();
                counter.CounterName = MagicValues.AvgTimeOfOp;
                counter.CounterHelp = "Átlagos végrehajtási idő";
                counter.CounterType = PerformanceCounterType.AverageTimer32;
                counters.Add(counter);

                counter = new CounterCreationData();
                counter.CounterName = MagicValues.AvgTimeOfOpBase;
                counter.CounterHelp = "Számítási alap az átlagos végrehajtási idő számításához";
                counter.CounterType = PerformanceCounterType.AverageBase;
                counters.Add(counter);

                PerformanceCounterCategory.Create(appName,
                    $"Teljesítménymutatók a {appName} alkalmazáshoz",
                    PerformanceCounterCategoryType.SingleInstance,
                    counters);
            }
        }

    }
}