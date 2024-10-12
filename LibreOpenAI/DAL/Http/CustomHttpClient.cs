using System.Net.Http.Headers;

namespace LibreOpenAI.DAL.Http
{
    public interface IHttpClient
    {
        HttpRequestHeaders DefaultRequestHeaders { get; }
        Task<HttpResponseMessage> PostAsync(Uri? requestUri, HttpContent? content);
    }

    public class CustomHttpClient : IHttpClient
    {
        private readonly HttpClient client;

        public CustomHttpClient(HttpClient client)
        {
            this.client = client;
        }

        public HttpRequestHeaders DefaultRequestHeaders => client.DefaultRequestHeaders;

        public async Task<HttpResponseMessage> PostAsync(Uri? requestUri, HttpContent? content)
        {
            return await client.PostAsync(requestUri, content);
        }
    }

}
