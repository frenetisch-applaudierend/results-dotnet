using System;
using BenchmarkDotNet.Attributes;

namespace Konoma.Results.Benchmarks
{
    public class VoidSuccessCase
    {
        [Benchmark]
        public bool UsingResults()
        {
            var result = DataProviderResults.GetVoidResult(10);
            return result.IsSuccess();
        }

        [Benchmark]
        public bool UsingExceptions()
        {
            try
            {
                DataProviderExceptions.GetVoidResult(10);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}