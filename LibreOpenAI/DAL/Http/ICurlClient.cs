using System.Net.Http.Headers;

namespace LibreOpenAI.DAL.Http
{
    public interface ICurlClient
    {
        IHttpClient Client { get; set; }
        HttpRequestHeaders DefaultRequestHeaders { get; }

        Task<HttpResponseMessage> CurlAsync(Uri url, string method, Dictionary<string, string> headers);
        Task<HttpResponseMessage> CurlAsync(Uri url, string method, Dictionary<string, string> headers, HttpContent content);
    }
}