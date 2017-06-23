using System;
using System.Collections.Generic;

namespace _08GarbageCollectorPerformance
{
    internal class TesztOsztaly : IDisposable
    {
        List<string> adat = new List<string>();

        public TesztOsztaly()
        {
            for (int i = 0; i < 10000; i++)
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
        }
    }
}