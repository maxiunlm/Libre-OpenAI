using System.Net.Http.Headers;

namespace LibreOpenAI.DAL.Http
{
    public partial class HttpClientAi : IHttpClientAi
    {
        private readonly HttpClient client;

        public HttpClientAi()
        {
            client = new HttpClient();
        }
        public HttpRequestHeaders DefaultRequestHeaders
        {
            get
            {
                return client.DefaultRequestHeaders;
            }
        }

        public async Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content)
        {
            HttpResponseMessage response = await client.PostAsync(requestUri, content);

            return response;
        }
    }
}
