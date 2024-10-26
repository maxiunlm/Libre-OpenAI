using System.Net;

namespace LibreOpenAI.Exceptions.OpenAI
{
    public class LibreOpenAiBadGatewayException : HttpRequestException
    {
        public LibreOpenAiBadGatewayException(HttpRequestException inner)
            : base("Server error from OpenAI because of a bad gateway. The service may be temporarily unavailable. Try again later.",
                  inner,
                  HttpStatusCode.BadGateway)
        { }
    }
}
