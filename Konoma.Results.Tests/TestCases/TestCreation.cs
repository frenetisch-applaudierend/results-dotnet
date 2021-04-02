using Konoma.Results.Tests.Utilities;
using Xunit;

namespace Konoma.Results.Tests.TestCases
{
    public class TestCreation
    {
        [Fact]
        public void EmptySuccessResultCanBeCreated()
        {
            var result = Result.Success();

            var successResult = Assert.IsType<SuccessResult<object, Error>>(result);

            Assert.Null(successResult.Data);
        }

        [Fact]
        public void EmptyErrorResultCanBeCreated()
        {
            var error = new Error("Test", 1, "Test error");
            var result = Result.Error(error);

            var errorResult = Assert.IsType<ErrorResult<object, Error>>(result);

            Assert.Same(error, errorResult.Error);
        }

        [Fact]
        public void PartiallyTypedSuccessResultCanBeCreated()
        {
            var data = "Hello, World!";
            var result = Result.Success(data);

            var successResult = Assert.IsType<SuccessResult<string, Error>>(result);

            Assert.Same(data, successResult.Data);
        }

        [Fact]
        public void PartiallyTypedErrorResultCanBeCreated()
        {
            var error = new Error("Test", 1, "Test error");
            var result = Result.Error<string>(error);

            var errorResult = Assert.IsType<ErrorResult<string, Error>>(result);

            Assert.Same(error, errorResult.Error);
        }

        [Fact]
        public void FullyTypedSuccessResultCanBeCreated()
        {
            var data = "Hello, World!";
            var result = Result.Success<string, TestError>(data);

            var successResult = Assert.IsType<SuccessResult<string, TestError>>(result);

            Assert.Same(data, successResult.Data);
        }

        [Fact]
        public void FullyTypedErrorResultCanBeCreated()
        {
            var error = new TestError();
            var result = Result.Error<string, TestError>(error);

            var errorResult = Assert.IsType<ErrorResult<string, TestError>>(result);

            Assert.Same(error, errorResult.Error);
        }
    }
}