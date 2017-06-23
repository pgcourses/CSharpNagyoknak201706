using System;
using System.Collections.Generic;
using System.Threading;

namespace _08GarbageCollectorPerformance
{
    public class TesztOsztaly : IDisposable
    {
        List<string> adat = new List<string>();

        public TesztOsztaly()
        {
            for (int i = 0; i < 100000; i++)
            {
                adat.Add(new string(' ', 1000));
            }
        }

        ~TesztOsztaly()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool isDispose)
        {
            if (isDispose)
            {
                adat.Clear();
            }
            //Thread.Sleep(0);
        }
    }
}