using BenchmarkDotNet.Running;

namespace Konoma.Results.Benchmarks
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }
}