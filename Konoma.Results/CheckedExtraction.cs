using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;

namespace Konoma.Results
{
    public static partial class ResultOperations
    {
        [Pure]
        public static bool IsSuccess(this Result result) => result.IsSuccess;

        [Pure]
        public static bool IsError(this Result result) => !result.IsSuccess;

        [Pure]
        public static bool IsError(this Result result, [NotNullWhen(true)] out Error? error)
        {
            error = result.ErrorValue;
            return !result.IsSuccess;
        }
    }
}