using BenchmarkDotNet.Attributes;
using System;
using System.Reflection;

namespace _07ReflectionBenchmark
{

    [MemoryDiagnoser]
    public class BenchmarkReflectionVsNative
    {
        private MethodInfo method;

        public BenchmarkReflectionVsNative()
        {
            var t = Assembly.GetExecutingAssembly()
                            .GetType("_07ReflectionBenchmark.BenchmarkReflectionVsNative");
            method = t.GetMethod("GetDate", BindingFlags.Static | BindingFlags.NonPublic);
        }

        [Benchmark]
        public object GetDateWithReflection()
        {
            return method.Invoke(null, null);
        }

        [Benchmark]
        public string GetDateWithReflectionFull()
        {
            var t = Assembly.GetExecutingAssembly()
                            .GetType("_07ReflectionBenchmark.BenchmarkReflectionVsNative");
            var m = t.GetMethod("GetDate", BindingFlags.Static | BindingFlags.NonPublic);
            return (string)m.Invoke(null, null);
        }

        [Benchmark(Baseline = true)]
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