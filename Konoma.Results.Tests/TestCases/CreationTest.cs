using System;
using Konoma.Results.Tests.Utilities;
using Xunit;

namespace Konoma.Results.Tests.TestCases
{
    public class CreationTest
    {
        [Fact]
        public void EmptySuccessResultCanBeCreated()
        {
            var result = Result.Success();

            var successResult = Assert.IsType<SuccessResult<object, Error>>(result);

            Assert.Null(successResult.SuccessValue);
            Assert.Null(successResult.ErrorValue);
        }

        [Fact]
        public void EmptyErrorResultCanBeCreated()
        {
            var error = new Error("Test", 1, "Test error");
            var result = Result.Error(error);

            var errorResult = Assert.IsType<ErrorResult<object, Error>>(result);

            Assert.Null(errorResult.SuccessValue);
            Assert.Same(error, errorResult.ErrorValue);
        }


        [Fact]
        public void PartiallyClassTypedSuccessResultCanBeCreated()
        {
            var data = "Hello, World!";
            var result = Result.Success(data);

            var successResult = Assert.IsType<SuccessResult<string, Error>>(result);

            Assert.Same(data, successResult.SuccessValue);
            Assert.Null(successResult.ErrorValue);
        }

        [Fact]
        public void PartiallyClassTypedErrorResultCanBeCreated()
        {
            var error = new Error("Test", 1, "Test error");
            var result = Result.Error<string>(error);

            var errorResult = Assert.IsType<ErrorResult<string, Error>>(result);

            Assert.Null(errorResult.SuccessValue);
            Assert.Same(error, errorResult.ErrorValue);
        }

        [Fact]
        public void PartiallyStructTypedSuccessResultCanBeCreated()
        {
            var data = Guid.NewGuid();
            var result = Result.Success(data);

            var successResult = Assert.IsType<SuccessResult<Guid, Error>>(result);

            Assert.Equal(data, successResult.SuccessValue);
            Assert.Null(successResult.ErrorValue);
        }

        [Fact]
        public void PartiallyStructTypedErrorResultCanBeCreated()
        {
            var error = new Error("Test", 1, "Test error");
            var result = Result.Error<Guid>(error);

            var errorResult = Assert.IsType<ErrorResult<Guid, Error>>(result);

            Assert.Equal(default, errorResult.SuccessValue);
            Assert.Same(error, errorResult.ErrorValue);
        }

        [Fact]
        public void PartiallyNullableStructTypedSuccessResultCanBeCreated()
        {
            var data = (Guid?) Guid.NewGuid();
            var result = Result.Success(data);

            var successResult = Assert.IsType<SuccessResult<Guid?, Error>>(result);

            Assert.Equal(data, successResult.SuccessValue);
            Assert.Null(successResult.ErrorValue);
        }

        [Fact]
        public void PartiallyNullableStructTypedErrorResultCanBeCreated()
        {
            var error = new Error("Test", 1, "Test error");
            var result = Result.Error<Guid?>(error);

            var errorResult = Assert.IsType<ErrorResult<Guid?, Error>>(result);

            Assert.Null(errorResult.SuccessValue);
            Assert.Same(error, errorResult.ErrorValue);
        }


        [Fact]
        public void FullyClassTypedSuccessResultCanBeCreated()
        {
            var data = "Hello, World!";
            var result = Result.Success<string, TestError>(data);

            var successResult = Assert.IsType<SuccessResult<string, TestError>>(result);

            Assert.Same(data, successResult.SuccessValue);
            Assert.Null(successResult.ErrorValue);
        }

        [Fact]
        public void FullyClassTypedErrorResultCanBeCreated()
        {
            var error = new TestError();
            var result = Result.Error<string, TestError>(error);

            var errorResult = Assert.IsType<ErrorResult<string, TestError>>(result);

            Assert.Null(errorResult.SuccessValue);
            Assert.Same(error, errorResult.ErrorValue);
        }

        [Fact]
        public void FullyStructTypedSuccessResultCanBeCreated()
        {
            var data = Guid.NewGuid();
            var result = Result.Success<Guid, TestError>(data);

            var successResult = Assert.IsType<SuccessResult<Guid, TestError>>(result);

            Assert.Equal(data, successResult.SuccessValue);
            Assert.Null(successResult.ErrorValue);
        }

        [Fact]
        public void FullyStructTypedErrorResultCanBeCreated()
        {
            var error = new TestError();
            var result = Result.Error<Guid, TestError>(error);

            var errorResult = Assert.IsType<ErrorResult<Guid, TestError>>(result);

            Assert.Equal(default, errorResult.SuccessValue);
            Assert.Same(error, errorResult.ErrorValue);
        }

        [Fact]
        public void FullyNullableStructTypedSuccessResultCanBeCreated()
        {
            var data = (Guid?) Guid.NewGuid();
            var result = Result.Success<Guid?, TestError>(data);

            var successResult = Assert.IsType<SuccessResult<Guid?, TestError>>(result);

            Assert.Equal(data, successResult.SuccessValue);
            Assert.Null(successResult.ErrorValue);
        }

        [Fact]
        public void FullyNullableStructTypedErrorResultCanBeCreated()
        {
            var error = new TestError();
            var result = Result.Error<Guid?, TestError>(error);

            var errorResult = Assert.IsType<ErrorResult<Guid?, TestError>>(result);

            Assert.Null(errorResult.SuccessValue);
            Assert.Same(error, errorResult.ErrorValue);
        }
    }
}