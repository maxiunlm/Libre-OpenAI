using System.Net.Http.Headers;

namespace LibreOpenAI.DAL.Http
{
    public class CustomHttpClient : IHttpClient
    {
        protected readonly HttpClient client;

        public CustomHttpClient(HttpClient client)
        {
            this.client = client;
        }

        public HttpRequestHeaders DefaultRequestHeaders => client.DefaultRequestHeaders;

        public async Task<HttpResponseMessage> PostAsync(Uri? requestUri, HttpContent? content)
        {
            return await client.PostAsync(requestUri, content);
        }

        public async Task<HttpResponseMessage> PostAsync(Uri? requestUri)
        {
            return await client.PostAsync(requestUri, null);
        }

        public async Task<HttpResponseMessage> GetAsync(Uri? requestUri)
        {
            return await client.GetAsync(requestUri);
        }

        public async Task<HttpResponseMessage> PutAsync(Uri? requestUri, HttpContent? content)
        {
            return await client.PutAsync(requestUri, content);
        }

        public async Task<HttpResponseMessage> PatchAsync(Uri? requestUri, HttpContent? content)
        {
            return await client.PatchAsync(requestUri, content);
        }

        public async Task<HttpResponseMessage> DeleteAsync(Uri? requestUri)
        {
            return await client.DeleteAsync(requestUri);
        }
    }
}
