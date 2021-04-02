using System.Diagnostics.Contracts;

namespace Konoma.Results
{
    public partial class Result
    {
        [Pure]
        public static Result Success() => new SuccessResult<object?, Error>(null);

        [Pure]
        public static Result Success<TData>(TData data) => new SuccessResult<TData, Error>(data);

        [Pure]
        public static Result Success<TData, TError>(TData data) where TError : Error =>
            new SuccessResult<TData, TError>(data);


        [Pure]
        public static Result Error<TError>(TError error) where TError : Error => new ErrorResult<object, TError>(error);

        [Pure]
        public static Result Error<TData>(Error error) => new ErrorResult<TData, Error>(error);

        [Pure]
        public static Result Error<TData, TError>(TError error) where TError : Error =>
            new ErrorResult<TData, TError>(error);
    }
}