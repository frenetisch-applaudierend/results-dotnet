using System;
using BenchmarkDotNet.Attributes;

namespace Konoma.Results.Benchmarks
{
    public class GuidSuccessCase
    {
        [Benchmark]
        public Guid? UsingResults()
        {
            var result = DataProviderResults.GetGuidResult(10);
            if (result.IsSuccess(out var guid))
                return guid;

            return null;
        }

        [Benchmark]
        public Guid? UsingExceptions()
        {
            try
            {
                return DataProviderExceptions.GetGuidResult(10);
            }
            catch
            {
                return null;
            }
        }
    }
}