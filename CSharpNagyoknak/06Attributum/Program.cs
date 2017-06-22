using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06Attributum
{
    class Program
    {
        static void Main(string[] args)
        {
            var o1 = new TesztOsztaly { Nev = "Ezt tesztelem", Mennyiseg = 5 };
            var o2 = new TesztOsztaly();
            //ValamitCsinal(); //ez így már le sem fordul

            var isValid1 = ValidationManager.Validate(o1);
            var isValid2 = ValidationManager.Validate(o2);

            Console.WriteLine("{0}, {1}", isValid1, isValid2);
            Console.ReadLine();

        }

        [Obsolete("Légyszi ne használd már",true)]
        public static void ValamitCsinal()
        {

        }

        [DebuggerDisplay("Nev={Nev}, Mennyiseg={Mennyiseg}")]
        class TesztOsztaly
        {
            public int Mennyiseg { get; set; }

            [Obsolete]
            [CSharpDDRequired] //Ez az attributum azt jelzi, hogy ez a mező nem maradhat kitöltetlen
            //[CSharpDDMaxLength(ErrorText = "Akármi bármi")] //Így tudom a publikus property-ket írni
            [CSharpDDMaxLength(5)] //Így pedig a konstruktort tudom hívni
            public string Nev { get; set; }
        }
    }

}
