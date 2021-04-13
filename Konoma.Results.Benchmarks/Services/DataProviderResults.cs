using System;

namespace Konoma.Results.Benchmarks
{
    public static class DataProviderResults
    {
        private static readonly Guid GuidValue = Guid.NewGuid();

        public static Result GetVoidResult(int input)
        {
            return input switch
            {
                0 => Result.Error(new Error("TestDomain", 1, "Invalid input")),

                _ => Result.Success()
            };
        }

        public static Result<Guid> GetGuidResult(int input)
        {
            return input switch
            {
                0 => Result.Error<Guid>(new Error("TestDomain", 1, "Invalid input")),

                _ => Result.Success(GuidValue)
            };
        }
    }
}