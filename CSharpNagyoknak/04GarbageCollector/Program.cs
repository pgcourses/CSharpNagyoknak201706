using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _04GarbageCollector
{
    class Program
    {
        static void Main(string[] args)
        {
            //CollectTest();
            while (!Console.KeyAvailable)
            {
                //var bm = new String('A', 1000000); //nem tömi el a memóriát, mert nincs véglegesítője. Viszont a GC folyamatosan fut
                //var bm = new Bitmap(1240, 1024) //eltömi a memóriát, mert van véglegesítője, és nincs idő a meghívására
                //using (var bm = new Bitmap(1240, 1024)) { } //nem tömi el a memóriát, mert nem hívja a véglegesitőt.
                //Kérdés: mi hogy tudunk ilyen osztályt írni?

                //eltömi a memóriát, mert van véglegesítője, 
                //és nincs idő a meghívására, ha nem implementálunk IDisposable-t
                //var bm = new TakaritandoPelda(); 
                using (var sajatOsztaly = new TakaritandoPelda()) { }

                //A using syntactic sugar, ezt generálja a fordító:
                //var sajatOsztaly = new TakaritandoPelda();
                //try
                //{
                //    //A sajátosztály műveletei vannak
                //}
                //finally
                //{
                //    ((IDisposable)sajatOsztaly).Dispose();
                //}
            }
        }

        private static void CollectTest()
        {
            Teszt();
            GC.Collect();
            Console.ReadLine();
        }

        private static void Teszt()
        {
            var hivatkozas = new TakaritandoPelda();
        }
    }

    public class TakaritandoPelda : IDisposable //ez kell ahhoz, hogy using kódblokkban használhassuk az osztályunk példányait
    {
        string sokmemoria = new String('A', 1000000);

        /// <summary>
        /// Létrehozó (Constructor)
        /// </summary>
        public TakaritandoPelda()
        {
            Console.WriteLine("Létrehozó");
        }

        /// <summary>
        /// Véglegesítő, ha ezt kivesszük, akkor nem tömi el a memóriát.
        /// </summary>
        ~TakaritandoPelda()
        {
            Console.WriteLine("Véglegesítő");
            Dispose(false);
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose");
            Dispose(true);
            GC.SuppressFinalize(this); //Ezzel jelzem, hogy nem kell finalizert hívni.
        }

        /// <summary>
        /// Ez a valódi takarítófüggvény, ami a függőségeimet megszünteti
        /// </summary>
        /// <param name="isDispose">megmondja, hogy a Dispose hívta (true) vagy a véglegesítő (f)</param>
        private void Dispose(bool isDispose)
        {
            if (isDispose)
            { //menedzselt rész takarítása
                Thread.Sleep(500);
                Console.WriteLine("Takarítás");
            }

            //nem menedzselt rész takarítása

        }
    }
}
