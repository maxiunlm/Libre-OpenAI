
namespace LibreOpenAI.OpenAi.CurlAi
{
    public interface ICurl
    {
        Task<HttpResponseMessage> CurlAsync(string url, string method, Dictionary<string, string> headers);
        Task<HttpResponseMessage> CurlAsync(string url, string method, Dictionary<string, string> headers, HttpContent content);
        Task<HttpResponseMessage> CurlAsync(Uri url, string method, Dictionary<string, string> headers);
        Task<HttpResponseMessage> CurlAsync(Uri url, string method, Dictionary<string, string> headers, HttpContent content);
    }
}