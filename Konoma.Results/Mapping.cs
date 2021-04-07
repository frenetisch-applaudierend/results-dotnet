using System;
using System.Diagnostics.Contracts;

namespace Konoma.Results
{
    public static partial class ResultOperations
    {
        [Pure]
        public static Result<TMappedData> Map<TMappedData>(this Result result, Func<TMappedData> valueMapping)
        {
            return result.IsError(out var error)
                ? (Result<TMappedData>) new ErrorResult<TMappedData, Error>(error)
                : new SuccessResult<TMappedData, Error>(valueMapping());
        }

        [Pure]
        public static Result<TMappedData, TMappedError> Map<TMappedData, TMappedError>(this Result result,
            Func<TMappedData> valueMapping, Func<Error, TMappedError> errorMapping)
            where TMappedError : Error
        {
            return result.IsError(out var error)
                ? (Result<TMappedData, TMappedError>) new ErrorResult<TMappedData, TMappedError>(errorMapping(error))
                : new SuccessResult<TMappedData, TMappedError>(valueMapping());
        }

        [Pure]
        public static Result<TMappedData> Map<TData, TMappedData>(this Result<TData> result,
            Func<TData, TMappedData> valueMapping)
        {
            return result.IsSuccess(out var data, out var error)
                ? (Result<TMappedData>) new SuccessResult<TMappedData, Error>(valueMapping(data))
                : new ErrorResult<TMappedData, Error>(error);
        }

        [Pure]
        public static Result<TMappedData, TMappedError> Map<TData, TMappedData, TMappedError>(this Result<TData> result,
            Func<TData, TMappedData> valueMapping, Func<Error, TMappedError> errorMapping)
            where TMappedError : Error
        {
            return result.IsSuccess(out var data, out var error)
                ? (Result<TMappedData, TMappedError>) new SuccessResult<TMappedData, TMappedError>(valueMapping(data))
                : new ErrorResult<TMappedData, TMappedError>(errorMapping(error));
        }

        [Pure]
        public static Result<TMappedData, TMappedError> Map<TData, TError, TMappedData, TMappedError>(
            this Result<TData, TError> result,
            Func<TData, TMappedData> valueMapping,
            Func<TError, TMappedError> errorMapping)
            where TError : Error
            where TMappedError : Error
        {
            return result.IsSuccess(out var data, out var error)
                ? (Result<TMappedData, TMappedError>) new SuccessResult<TMappedData, TMappedError>(valueMapping(data))
                : new ErrorResult<TMappedData, TMappedError>(errorMapping(error));
        }
    }
}