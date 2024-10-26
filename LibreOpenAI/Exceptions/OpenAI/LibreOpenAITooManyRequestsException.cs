using System.Net;

namespace LibreOpenAI.Exceptions.OpenAI
{
    public class LibreOpenAITooManyRequestsException : HttpRequestException
    {
        public LibreOpenAITooManyRequestsException(HttpRequestException inner)
            : base("Error 429: You have exceeded the request limit. Try reducing the frequency of requests.",
                  inner, 
                  HttpStatusCode.TooManyRequests)
        { }
    }
}
