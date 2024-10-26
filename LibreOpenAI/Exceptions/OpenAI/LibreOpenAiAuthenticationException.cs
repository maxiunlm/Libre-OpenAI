using System.Net;

namespace LibreOpenAI.Exceptions.OpenAI
{
    public class LibreOpenAiAuthenticationException : HttpRequestException
    {
        public LibreOpenAiAuthenticationException(HttpRequestException inner)
            : base("Error 401: Invalid or missing API key. Verify your API key and try again.",
                  inner,
                  HttpStatusCode.Unauthorized)
        { }
    }
}
