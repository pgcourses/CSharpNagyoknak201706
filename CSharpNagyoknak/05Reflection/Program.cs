using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _05Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            //típus megadása 'hagyományos' módon
            var t1 = typeof(Program);

            //A függvényünk meghívása 'hagyományos módon'
            string datumEsIdo1 = DatumEsIdo();

            //típus megadása reflection-nel, az assembly mi magunk vagyunk
            var t2 = Assembly.GetExecutingAssembly().GetType("_05Reflection.Program");
            //függvényünk meghívása Reflection-nel
            var m2 = t2.GetMethod("DatumEsIdo", BindingFlags.Static | BindingFlags.Public);
            var datumEsIdo2 = m2.Invoke(null, null);

            //ugyanez. csak assembly betöltése dll-ből
            var assembly = Assembly.LoadFrom("05Reflection.exe");
            var t3 = assembly.GetType("_05Reflection.Program");
            //függvényünk meghívása Reflection-nel
            var m3 = t3.GetMethod("DatumEsIdo", BindingFlags.Static | BindingFlags.Public);
            var datumEsIdo3 = m2.Invoke(null, null);

            Console.WriteLine(datumEsIdo1);
            Console.WriteLine(datumEsIdo2);
            Console.WriteLine(datumEsIdo3);

            //le is tudjuk kérdezni a felületet a reflection segítségével
            ListAllMethods(t3);

            Console.ReadLine();
        }

        private static void ListAllMethods(Type t3)
        {
            var methodInfos = t3.GetMethods();

            Console.WriteLine(t3.Name);

            foreach (var methodInfo in methodInfos)
            {
                var paramInfos = methodInfo.GetParameters();
                var prms = string.Join(",", paramInfos.Select(pi => $"{pi.ParameterType.Name} {pi.Name}"));
                Console.WriteLine("{0} {1} ({2})",methodInfo.ReturnType.Name, methodInfo.Name, prms);
            }
        }

        public static string DatumEsIdo()
        {
            return DateTime.Now.ToString();
        }

        public DateTime EzEgyAkarmi(bool isOk, int szam, string szoveg) { return DateTime.Now; }
    }
}
