namespace Konoma.Results
{
    public abstract partial class Result
    {
        internal abstract bool IsSuccessResult { get; }

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

    internal class SuccessResult<TData, TError> : Result<TData, TError>
        where TError : Error
    {
        public SuccessResult(TData data)
        {
            SuccessValue = data;
        }

        internal override bool IsSuccessResult => true;

        internal override TData SuccessValue { get; }

        internal override Error? ErrorValue => null;
    }

    internal class ErrorResult<TData, TError> : Result<TData, TError>
        where TError : Error
    {
        public ErrorResult(TError error)
        {
            _error = error;
        }

        private readonly TError _error;

        internal override bool IsSuccessResult => false;

        internal override TData SuccessValue => default!;

        internal override Error ErrorValue => _error;
    }
}