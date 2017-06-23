using System;
using System.Reflection;

namespace _07ReflectionBenchmark
{

    public class BenchmarkReflectionVsNative
    {
        private MethodInfo method;

        public BenchmarkReflectionVsNative()
        {
            var t = Assembly.GetExecutingAssembly()
                            .GetType("_07ReflectionBenchmark.BenchmarkReflectionVsNative");
            method = t.GetMethod("GetDate", BindingFlags.Static | BindingFlags.NonPublic);
        }

        public object GetDateWithReflection()
        {
            return method.Invoke(null, null);
        }

        public string GetDateWithReflectionFull()
        {
            var t = Assembly.GetExecutingAssembly()
                            .GetType("_07ReflectionBenchmark.BenchmarkReflectionVsNative");
            var m = t.GetMethod("GetDate", BindingFlags.Static | BindingFlags.NonPublic);
            return (string)m.Invoke(null, null);
        }

        public string GetDateWithoutReflection()
        {
            return GetDate();
        }

        static string GetDate()
        {
            return DateTime.Now.ToString();
        }

    }
}