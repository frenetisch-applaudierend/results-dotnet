using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;

namespace Konoma.Results
{
    public static partial class ResultOperations
    {
        [Pure]
        public static bool IsSuccess(this Result result) => result.IsSuccess;

        [Pure]
        public static bool IsSuccess<TData>(this Result<TData> result, [MaybeNullWhen(false)] out TData data)
        {
            data = result.SuccessValue;
            return result.IsSuccess;
        }

        [Pure]
        public static bool IsSuccess<TData, TError>(
            this Result<TData, TError> result,
            [MaybeNullWhen(false)] out TData data,
            [NotNullWhen(false)] out TError? error)
            where TError : Error
        {
            data = result.SuccessValue;
            error = (TError?) result.ErrorValue;
            return result.IsSuccess;
        }


        [Pure]
        public static bool IsError(this Result result) => !result.IsSuccess;

        [Pure]
        public static bool IsError(this Result result, [NotNullWhen(true)] out Error? error)
        {
            error = result.ErrorValue;
            return !result.IsSuccess;
        }

        [Pure]
        public static bool IsError<TData, TError>(
            this Result<TData, TError> result,
            [MaybeNullWhen(true)] out TData data,
            [NotNullWhen(true)] out TError? error)
            where TError : Error
        {
            data = result.SuccessValue;
            error = (TError?) result.ErrorValue;
            return !result.IsSuccess;
        }
    }
}