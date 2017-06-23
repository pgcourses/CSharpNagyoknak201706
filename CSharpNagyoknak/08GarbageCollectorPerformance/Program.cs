using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08GarbageCollectorPerformance
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Console.WriteLine("using-gal");
                while (!Console.KeyAvailable)
                {
                    using (var teszt = new TesztOsztaly()) { }
                }
            }
            else
            {
                Console.WriteLine("using nélkül");
                while (!Console.KeyAvailable)
                {
                    var teszt = new TesztOsztaly();
                }
            }
        }
    }
}
