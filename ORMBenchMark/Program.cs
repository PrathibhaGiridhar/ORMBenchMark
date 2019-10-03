using BenchmarkDotNet.Running;
using System;

namespace ORMBenchMark
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run(typeof(EFCoreVsDapper), new BenchmarkDotNet.Configs.DebugInProcessConfig());
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
