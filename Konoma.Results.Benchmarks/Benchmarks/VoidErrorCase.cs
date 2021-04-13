using BenchmarkDotNet.Attributes;

namespace Konoma.Results.Benchmarks
{
    public class VoidErrorCase
    {
        [Benchmark]
        public bool UsingResults()
        {
            var result = DataProviderResults.GetVoidResult(0);
            return result.IsSuccess();
        }

        [Benchmark]
        public bool UsingExceptions()
        {
            try
            {
                DataProviderExceptions.GetVoidResult(0);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}