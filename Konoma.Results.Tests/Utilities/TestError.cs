namespace Konoma.Results.Tests.Utilities
{
    public class TestError : Error
    {
        public TestError() : base("Test Error", 666, "Test Message")
        {
        }
    }
}