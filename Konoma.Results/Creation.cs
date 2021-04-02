using System.Diagnostics.Contracts;

namespace Konoma.Results
{
    public partial class Result
    {
        [Pure]
        public static Result Success() => new SuccessResult<object?, Error>(null);

        [Pure]
        public static Result<TData> Success<TData>(TData data) => new SuccessResult<TData, Error>(data);

        [Pure]
        public static Result<TData, TError> Success<TData, TError>(TData data) where TError : Error =>
            new SuccessResult<TData, TError>(data);


        [Pure]
        public static Result Error(Error error) => new ErrorResult<object, Error>(error);

        [Pure]
        public static Result<TData> Error<TData>(Error error) => new ErrorResult<TData, Error>(error);

        [Pure]
        public static Result<TData, TError> Error<TData, TError>(TError error) where TError : Error =>
            new ErrorResult<TData, TError>(error);
    }
}