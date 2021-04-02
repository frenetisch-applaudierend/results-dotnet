using System;
using Konoma.Results.Tests.Utilities;
using Xunit;

namespace Konoma.Results.Tests.TestCases
{
    public class CheckedExtractionTest
    {
        [Fact]
        public void EmptySuccessResultCanBeChecked()
        {
            var result = Result.Success();

            Assert.True(result.IsSuccess());
            Assert.False(result.IsError());
        }

        [Fact]
        public void EmptyErrorResultCanBeCheckedAndExtracted()
        {
            var error = new TestError();
            var result = Result.Error(error);

            Assert.False(result.IsSuccess());
            Assert.True(result.IsError());

            Assert.True(result.IsError(out var resultError));

            Assert.Same(error, resultError);
        }


        [Fact]
        public void PartiallyClassTypedSuccessResultCanBeCheckedAndExtracted()
        {
            var data = "Hello, World!";
            var result = Result.Success(data);

            Assert.True(result.IsSuccess());
            Assert.False(result.IsError());

            Assert.True(result.IsSuccess(out var resultData1));
            Assert.False(result.IsError(out var resultError1));

            Assert.True(result.IsSuccess(out var resultData2, out var resultError2));
            Assert.False(result.IsError(out var resultData3, out var resultError3));

            Assert.Same(data, resultData1);
            Assert.Null(resultError1);

            Assert.Same(data, resultData2);
            Assert.Null(resultError2);

            Assert.Same(data, resultData3);
            Assert.Null(resultError3);
        }

        [Fact]
        public void PartiallyClassTypedErrorResultCanBeCheckedAndExtracted()
        {
            var error = new TestError();
            var result = Result.Error<string>(error);

            Assert.False(result.IsSuccess());
            Assert.True(result.IsError());

            Assert.False(result.IsSuccess(out var resultData1));
            Assert.True(result.IsError(out var resultError1));

            Assert.False(result.IsSuccess(out var resultData2, out var resultError2));
            Assert.True(result.IsError(out var resultData3, out var resultError3));

            Assert.Null(resultData1);
            Assert.Same(error, resultError1);

            Assert.Null(resultData2);
            Assert.Same(error, resultError2);

            Assert.Null(resultData3);
            Assert.Same(error, resultError3);
        }

        [Fact]
        public void PartiallyStructTypedSuccessResultCanBeCheckedAndExtracted()
        {
            var data = Guid.NewGuid();
            var result = Result.Success(data);

            Assert.True(result.IsSuccess());
            Assert.False(result.IsError());

            Assert.True(result.IsSuccess(out var resultData1));
            Assert.False(result.IsError(out var resultError1));

            Assert.True(result.IsSuccess(out var resultData2, out var resultError2));
            Assert.False(result.IsError(out var resultData3, out var resultError3));

            Assert.Equal(data, resultData1);
            Assert.Null(resultError1);

            Assert.Equal(data, resultData2);
            Assert.Null(resultError2);

            Assert.Equal(data, resultData3);
            Assert.Null(resultError3);
        }

        [Fact]
        public void PartiallyStructTypedErrorResultCanBeCheckedAndExtracted()
        {
            var error = new TestError();
            var result = Result.Error<Guid>(error);

            Assert.False(result.IsSuccess());
            Assert.True(result.IsError());

            Assert.False(result.IsSuccess(out var resultData1));
            Assert.True(result.IsError(out var resultError1));

            Assert.False(result.IsSuccess(out var resultData2, out var resultError2));
            Assert.True(result.IsError(out var resultData3, out var resultError3));

            Assert.Equal(default, resultData1);
            Assert.Same(error, resultError1);

            Assert.Equal(default, resultData2);
            Assert.Same(error, resultError2);

            Assert.Equal(default, resultData3);
            Assert.Same(error, resultError3);
        }

        [Fact]
        public void PartiallyNullableStructTypedSuccessResultCanBeCheckedAndExtracted()
        {
            var data = (Guid?) Guid.NewGuid();
            var result = Result.Success(data);

            Assert.True(result.IsSuccess());
            Assert.False(result.IsError());

            Assert.True(result.IsSuccess(out var resultData1));
            Assert.False(result.IsError(out var resultError1));

            Assert.True(result.IsSuccess(out var resultData2, out var resultError2));
            Assert.False(result.IsError(out var resultData3, out var resultError3));

            Assert.Equal(data, resultData1);
            Assert.Null(resultError1);

            Assert.Equal(data, resultData2);
            Assert.Null(resultError2);

            Assert.Equal(data, resultData2);
            Assert.Null(resultError2);
        }

        [Fact]
        public void PartiallyNullableStructTypedErrorResultCanBeCheckedAndExtracted()
        {
            var error = new TestError();
            var result = Result.Error<Guid?>(error);

            Assert.False(result.IsSuccess());
            Assert.True(result.IsError());

            Assert.False(result.IsSuccess(out var resultData1));
            Assert.True(result.IsError(out var resultError1));

            Assert.False(result.IsSuccess(out var resultData2, out var resultError2));
            Assert.True(result.IsError(out var resultData3, out var resultError3));

            Assert.Equal(default, resultData1);
            Assert.Same(error, resultError1);

            Assert.Equal(default, resultData2);
            Assert.Same(error, resultError2);

            Assert.Equal(default, resultData3);
            Assert.Same(error, resultError3);
        }


        [Fact]
        public void FullyClassTypedSuccessResultCanBeCheckedAndExtracted()
        {
            var data = "Hello, World!";
            var result = Result.Success<string, TestError>(data);

            Assert.True(result.IsSuccess());
            Assert.False(result.IsError());

            Assert.True(result.IsSuccess(out var resultData1));
            Assert.False(result.IsError(out var resultError1));

            Assert.True(result.IsSuccess(out var resultData2, out var resultError2));
            Assert.False(result.IsError(out var resultData3, out var resultError3));

            Assert.Same(data, resultData1);
            Assert.Null(resultError1);

            Assert.Same(data, resultData2);
            Assert.Null(resultError2);

            Assert.Same(data, resultData3);
            Assert.Null(resultError3);
        }

        [Fact]
        public void FullyClassTypedErrorResultCanBeCheckedAndExtracted()
        {
            var error = new TestError();
            var result = Result.Error<string, TestError>(error);

            Assert.False(result.IsSuccess());
            Assert.True(result.IsError());

            Assert.False(result.IsSuccess(out var resultData1));
            Assert.True(result.IsError(out var resultError1));

            Assert.False(result.IsSuccess(out var resultData2, out var resultError2));
            Assert.True(result.IsError(out var resultData3, out var resultError3));

            Assert.Null(resultData1);
            Assert.Same(error, resultError1);

            Assert.Null(resultData2);
            Assert.Same(error, resultError2);

            Assert.Null(resultData3);
            Assert.Same(error, resultError3);
        }

        [Fact]
        public void FullyStructTypedSuccessResultCanBeCheckedAndExtracted()
        {
            var data = Guid.NewGuid();
            var result = Result.Success<Guid, TestError>(data);

            Assert.True(result.IsSuccess());
            Assert.False(result.IsError());

            Assert.True(result.IsSuccess(out var resultData1));
            Assert.False(result.IsError(out var resultError1));

            Assert.True(result.IsSuccess(out var resultData2, out var resultError2));
            Assert.False(result.IsError(out var resultData3, out var resultError3));

            Assert.Equal(data, resultData1);
            Assert.Null(resultError1);

            Assert.Equal(data, resultData2);
            Assert.Null(resultError2);

            Assert.Equal(data, resultData3);
            Assert.Null(resultError3);
        }

        [Fact]
        public void FullyStructTypedErrorResultCanBeCheckedAndExtracted()
        {
            var error = new TestError();
            var result = Result.Error<Guid, TestError>(error);

            Assert.False(result.IsSuccess());
            Assert.True(result.IsError());

            Assert.False(result.IsSuccess(out var resultData1));
            Assert.True(result.IsError(out var resultError1));

            Assert.False(result.IsSuccess(out var resultData2, out var resultError2));
            Assert.True(result.IsError(out var resultData3, out var resultError3));

            Assert.Equal(default, resultData1);
            Assert.Same(error, resultError1);

            Assert.Equal(default, resultData2);
            Assert.Same(error, resultError2);

            Assert.Equal(default, resultData3);
            Assert.Same(error, resultError3);
        }

        [Fact]
        public void FullyNullableStructTypedSuccessResultCanBeCheckedAndExtracted()
        {
            var data = (Guid?) Guid.NewGuid();
            var result = Result.Success<Guid?, TestError>(data);

            Assert.True(result.IsSuccess());
            Assert.False(result.IsError());

            Assert.True(result.IsSuccess(out var resultData1));
            Assert.False(result.IsError(out var resultError1));

            Assert.True(result.IsSuccess(out var resultData2, out var resultError2));
            Assert.False(result.IsError(out var resultData3, out var resultError3));

            Assert.Equal(data, resultData1);
            Assert.Null(resultError1);

            Assert.Equal(data, resultData2);
            Assert.Null(resultError2);

            Assert.Equal(data, resultData3);
            Assert.Null(resultError3);
        }

        [Fact]
        public void FullyNullableStructTypedErrorResultCanBeCheckedAndExtracted()
        {
            var error = new TestError();
            var result = Result.Error<Guid?, TestError>(error);

            Assert.False(result.IsSuccess());
            Assert.True(result.IsError());

            Assert.False(result.IsSuccess(out var resultData1));
            Assert.True(result.IsError(out var resultError1));

            Assert.False(result.IsSuccess(out var resultData2, out var resultError2));
            Assert.True(result.IsError(out var resultData3, out var resultError3));

            Assert.Equal(default, resultData1);
            Assert.Same(error, resultError1);

            Assert.Equal(default, resultData2);
            Assert.Same(error, resultError2);

            Assert.Equal(default, resultData3);
            Assert.Same(error, resultError3);
        }
    }
}