using System;
using System.Threading.Tasks;

namespace Konoma.Results
{
    public static partial class ResultOperations
    {
        public static Task<Result> ThenAsync<TData, TError>(
            this Task<Result<TData, TError>> resultTask,
            Func<TData, Task> continuation)
            where TError : Error
        {
            throw new NotImplementedException();
        }
    }
}