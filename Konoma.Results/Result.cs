namespace Konoma.Results
{
    public abstract partial class Result
    {
        internal abstract bool IsSuccess { get; }

        internal abstract Error? ErrorValue { get; }
    }

    public abstract class Result<TData> : Result
    {
        internal abstract TData SuccessValue { get; }
    }

    public abstract class Result<TData, TError> : Result<TData>
        where TError : Error
    {
    }

    public class SuccessResult<TData, TError> : Result<TData, TError>
        where TError : Error
    {
        public SuccessResult(TData data)
        {
            Data = data;
        }

        public TData Data { get; }

        internal override bool IsSuccess => true;

        internal override TData SuccessValue => Data;

        internal override Error? ErrorValue => null;
    }

    public class ErrorResult<TData, TError> : Result<TData, TError>
        where TError : Error
    {
        public ErrorResult(TError error)
        {
            Error = error;
        }

        public TError Error { get; }

        internal override bool IsSuccess => false;

        internal override TData SuccessValue => default!;

        internal override Error ErrorValue => Error;
    }
}