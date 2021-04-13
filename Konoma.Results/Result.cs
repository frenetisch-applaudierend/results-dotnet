namespace Konoma.Results
{
    public readonly partial struct Result
    {
        private Result(Error? errorValue)
        {
            ErrorValue = errorValue;
        }

        private Error? ErrorValue { get; }

        private bool IsSuccessResult => ErrorValue is null;
    }

    public readonly partial struct Result<TData>
    {
        internal Result(TData successValue, Error? errorValue)
        {
            SuccessValue = successValue;
            ErrorValue = errorValue;
        }

        private TData SuccessValue { get; }

        private Error? ErrorValue { get; }

        private bool IsSuccessResult => ErrorValue is null;
    }

    public readonly partial struct Result<TData, TError>
        where TError : Error
    {
        internal Result(TData successValue, TError? errorValue)
        {
            SuccessValue = successValue;
            ErrorValue = errorValue;
        }

        private TData SuccessValue { get; }

        private TError? ErrorValue { get; }

        private bool IsSuccessResult => ErrorValue is null;
    }
}