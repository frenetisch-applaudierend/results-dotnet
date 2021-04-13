using System;

namespace Konoma.Results.Benchmarks
{
    public static class DataProviderExceptions
    {
        private static readonly Guid GuidValue = Guid.NewGuid();

        public static void GetVoidResult(int input)
        {
            if (input == 0)
                throw new ArgumentOutOfRangeException(nameof(input), "Invalid input");
        }

        public static Guid GetGuidResult(int input)
        {
            if (input == 0)
                throw new ArgumentOutOfRangeException(nameof(input), "Invalid input");

            return GuidValue;
        }
    }
}