using System;
using BenchmarkDotNet.Attributes;

namespace Konoma.Results.Benchmarks
{
    public class GuidErrorCase
    {
        [Benchmark]
        public Guid? UsingResults()
        {
            var result = DataProviderResults.GetGuidResult(0);
            if (result.IsSuccess(out var guid))
                return guid;

            return null;
        }

        [Benchmark]
        public Guid? UsingExceptions()
        {
            try
            {
                return DataProviderExceptions.GetGuidResult(0);
            }
            catch
            {
                return null;
            }
        }
    }
}