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
    }
}
