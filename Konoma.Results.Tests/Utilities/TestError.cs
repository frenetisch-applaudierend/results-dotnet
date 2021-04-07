namespace Konoma.Results.Tests.Utilities
{
    public class TestError : Error
    {
        public TestError() : base("Test Error", 666, "Test Message")
        {
        }

        public TestError(string message) : base("Test Error", 666, message)
        {
        }
    }
}