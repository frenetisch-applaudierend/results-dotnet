using Konoma.Results.Tests.Utilities;
using Xunit;

namespace Konoma.Results.Tests.TestCases
{
    public class MappingTest
    {
        [Fact]
        public void EmptySuccessResultMapsToPartiallyTypedValue()
        {
            var result = Result.Success();

            Result<string> mapped = result.Map(() => "Hello");

            Assert.True(mapped.IsSuccess(out var resultSuccess));

            Assert.Equal("Hello", resultSuccess);
        }

        [Fact]
        public void EmptyErrorResultMapsToPartiallyTypedValue()
        {
            var error = new TestError();
            var result = Result.Error(error);

            Result<string> mapped = result.Map(() => "Hello");

            Assert.True(mapped.IsError(out var resultError));

            Assert.Same(error, resultError);
        }

        [Fact]
        public void EmptySuccessResultMapsToExplicitFullyTypedValue()
        {
            var result = Result.Success();

            Result<string, TestError> mapped = result.Map(() => "Hello", error => new TestError(error.Message));

            Assert.True(mapped.IsSuccess(out var resultSuccess));

            Assert.Equal("Hello", resultSuccess);
        }

        [Fact]
        public void EmptyErrorResultMapsToExplicitFullyTypedValue()
        {
            var inError = new TestError();
            var outError = new TestError(inError.Message);
            var result = Result.Error(inError);

            Result<string, TestError> mapped = result.Map(() => "Hello", _ => outError);

            Assert.True(mapped.IsError(out var resultError));

            Assert.Same(outError, resultError);
        }
    }
}