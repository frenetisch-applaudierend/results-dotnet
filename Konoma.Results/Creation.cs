using System.Diagnostics.Contracts;

namespace Konoma.Results
{
    public partial struct Result
    {
        [Pure]
        public static Result Success() => new Result(null);

        [Pure]
        public static Result<TData> Success<TData>(TData data) => new Result<TData>(data, null);

        [Pure]
        public static Result<TData, TError> Success<TData, TError>(TData data) where TError : Error =>
            new Result<TData, TError>(data, null);


        [Pure]
        public static Result Error(Error error) => new Result(error);

        [Pure]
        public static Result<TData> Error<TData>(Error error) => new Result<TData>(default!, error);

        [Pure]
        public static Result<TData, TError> Error<TData, TError>(TError error) where TError : Error =>
            new Result<TData, TError>(default!, error);
    }
}