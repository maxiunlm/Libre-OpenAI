using System.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;

namespace LibreOpenAI.DAL.Http
{
    public partial class HttpClientAi : IHttpClientAi
    {
        private IHttpClient? client;

        public HttpRequestHeaders DefaultRequestHeaders
        {
            get
            {
                return Client.DefaultRequestHeaders;
            }
        }

        public IHttpClient Client
        {
            get
            {
                if(client == null)
                {
                    var serviceProvider = new ServiceCollection()
                        .AddHttpClient()
                        .BuildServiceProvider();

                    IHttpClientFactory clientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
                    HttpClient client = clientFactory.CreateClient();
                    this.client = new CustomHttpClient(client);
                }

                return client;
            }
            set => client = value;
        }

        public async Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content)
        {
            HttpResponseMessage response = await Client.PostAsync(requestUri, content);

            return response;
        }
    }
}
