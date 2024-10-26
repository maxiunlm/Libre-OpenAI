using System.Net;

namespace LibreOpenAI.Exceptions.OpenAI
{
    public class LibreOpenAiGatewayTimeoutException : HttpRequestException
    {
        public LibreOpenAiGatewayTimeoutException(HttpRequestException inner)
            : base("Server error from OpenAI because of a gateway timeout. The service may be temporarily unavailable. Try again later.",
                  inner,
                  HttpStatusCode.GatewayTimeout)
        { }
    }
}