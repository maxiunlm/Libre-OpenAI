using System.Net;

namespace LibreOpenAI.Exceptions.OpenAI
{
    public class LibreOpenAiInternalServerErrorException : HttpRequestException
    {
        public LibreOpenAiInternalServerErrorException(HttpRequestException inner)
            : base("Internal server error from OpenAI. The service may be temporarily unavailable. Try again later.",
                  inner,
                  HttpStatusCode.InternalServerError)
        { }
    }
}
