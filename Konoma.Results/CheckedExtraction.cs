using System.Diagnostics.CodeAnalysis;

namespace Konoma.Results
{
    public partial struct Result
    {
        public bool IsSuccess() => IsSuccessResult;

        public bool IsError() => !IsSuccessResult;

        public bool IsError([NotNullWhen(true)] out Error? error)
        {
            error = ErrorValue;
            return !IsSuccessResult;
        }
    }

    public partial struct Result<TData>
    {
        public bool IsSuccess() => IsSuccessResult;

        public bool IsSuccess([MaybeNullWhen(false)] out TData data)
        {
            data = SuccessValue!;
            return IsSuccessResult;
        }

        public bool IsSuccess([MaybeNullWhen(false)] out TData data, [NotNullWhen(false)] out Error? error)
        {
            data = SuccessValue!;
            error = ErrorValue;
            return IsSuccessResult;
        }

        public bool IsError() => !IsSuccessResult;

        public bool IsError([NotNullWhen(true)] out Error? error)
        {
            error = ErrorValue;
            return !IsSuccessResult;
        }

        public bool IsError([MaybeNullWhen(true)] out TData data, [NotNullWhen(true)] out Error? error)
        {
            data = SuccessValue!;
            error = ErrorValue;
            return !IsSuccessResult;
        }
    }

    public partial struct Result<TData, TError>
        where TError : Error
    {
        public bool IsSuccess() => IsSuccessResult;

        public bool IsSuccess([MaybeNullWhen(false)] out TData data)
        {
            data = SuccessValue!;
            return IsSuccessResult;
        }

        public bool IsSuccess([MaybeNullWhen(false)] out TData data, [NotNullWhen(false)] out TError? error)
        {
            data = SuccessValue!;
            error = ErrorValue;
            return IsSuccessResult;
        }

        public bool IsError() => !IsSuccessResult;

        public bool IsError([NotNullWhen(true)] out TError? error)
        {
            error = ErrorValue;
            return !IsSuccessResult;
        }

        public bool IsError([MaybeNullWhen(true)] out TData data, [NotNullWhen(true)] out TError? error)
        {
            data = SuccessValue!;
            error = ErrorValue;
            return !IsSuccessResult;
        }
    }
}