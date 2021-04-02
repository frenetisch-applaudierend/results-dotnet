namespace Konoma.Results
{
    public class Error
    {
        public Error(string domain, int code, string message)
        {
            Domain = domain;
            Code = code;
            Message = message;
        }

        public string Domain { get; }

        public int Code { get; }

        public string Message { get; }
    }
}