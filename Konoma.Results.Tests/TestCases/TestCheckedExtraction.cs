using Konoma.Results.Tests.Utilities;
using Xunit;

namespace Konoma.Results.Tests.TestCases
{
    public class TestCheckedExtraction
    {
        [Fact]
        public void EmptySuccessResultCanBeChecked()
        {
            var result = Result.Success();

            Assert.True(result.IsSuccess());
            Assert.False(result.IsError());
        }

        [Fact]
        public void EmptyErrorResultCanBeChecked()
        {
            var error = new TestError();
            var result = Result.Error(error);

            Assert.False(result.IsSuccess());
            Assert.True(result.IsError());
        }

        [Fact]
        public void EmptyErrorResultCanBeExtracted()
        {
            var error = new TestError();
            var result = Result.Error(error);

            _ = result.IsError(out var resultError);

            Assert.Same(error, resultError);
        }
    }
}