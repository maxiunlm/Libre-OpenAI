namespace LibreOpenAI.DAL.Http
{
    public class CustomHttpExtensionClient : CustomHttpClient, IHttpExtensionClient
    {
        public CustomHttpExtensionClient(HttpClient client) : base(client)
        {
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
