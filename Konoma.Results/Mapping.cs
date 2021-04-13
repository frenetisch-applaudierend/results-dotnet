using System;

namespace Konoma.Results
{
    public partial struct Result
    {
        public Result<TMappedData> Map<TMappedData>(Func<TMappedData> valueMapping) =>
            IsSuccessResult
                ? new Result<TMappedData>(valueMapping(), null)
                : new Result<TMappedData>(default!, ErrorValue);

        public Result<TMappedData, TMappedError> Map<TMappedData, TMappedError>(
            Func<TMappedData> valueMapping,
            Func<Error, TMappedError> errorMapping)
            where TMappedError : Error =>
            IsSuccessResult
                ? new Result<TMappedData, TMappedError>(valueMapping(), null)
                : new Result<TMappedData, TMappedError>(default!, errorMapping(ErrorValue!));
    }

    public partial struct Result<TData>
    {
        public Result<TMappedData> Map<TMappedData>(Func<TData, TMappedData> valueMapping) =>
            IsSuccessResult
                ? new Result<TMappedData>(valueMapping(SuccessValue), null)
                : new Result<TMappedData>(default!, ErrorValue);

        public Result<TMappedData, TMappedError> Map<TMappedData, TMappedError>(
            Func<TData, TMappedData> valueMapping,
            Func<Error, TMappedError> errorMapping)
            where TMappedError : Error =>
            IsSuccessResult
                ? new Result<TMappedData, TMappedError>(valueMapping(SuccessValue), null)
                : new Result<TMappedData, TMappedError>(default!, errorMapping(ErrorValue!));

        public static implicit operator Result(Result<TData> result) => new Result(result.ErrorValue);

        public static implicit operator Result<TData, Error>(Result<TData> result) =>
            new Result<TData, Error>(result.SuccessValue, result.ErrorValue);
    }

    public partial struct Result<TData, TError>
    {
        public Result<TMappedData, TError> Map<TMappedData>(Func<TData, TMappedData> valueMapping) =>
            IsSuccessResult
                ? new Result<TMappedData, TError>(valueMapping(SuccessValue), null)
                : new Result<TMappedData, TError>(default!, ErrorValue);

        public Result<TMappedData, TMappedError> Map<TMappedData, TMappedError>(
            Func<TData, TMappedData> valueMapping,
            Func<TError, TMappedError> errorMapping)
            where TMappedError : Error =>
            IsSuccessResult
                ? new Result<TMappedData, TMappedError>(valueMapping(SuccessValue), null)
                : new Result<TMappedData, TMappedError>(default!, errorMapping(ErrorValue!));

        public static implicit operator Result(Result<TData, TError> result) => new Result(result.ErrorValue);

        public static implicit operator Result<TData>(Result<TData, TError> result) =>
            new Result<TData>(result.SuccessValue, result.ErrorValue);

        public static implicit operator Result<TData, Error>(Result<TData, TError> result) =>
            new Result<TData, Error>(result.SuccessValue, result.ErrorValue);

        public static explicit operator Result<TData, TError>(Result<TData> result) =>
            result.Map(v => v, e => (TError) e);
    }
}