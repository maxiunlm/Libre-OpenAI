using System.Net;

namespace LibreOpenAI.Exceptions.OpenAI
{
    public class LibreOpenAiServiceUnavailableException : HttpRequestException
    {
        public LibreOpenAiServiceUnavailableException(HttpRequestException inner)
            : base("Server error from OpenAI. The service may be temporarily unavailable. Try again later.",
                  inner,
                  HttpStatusCode.ServiceUnavailable)
        { }
    }
}