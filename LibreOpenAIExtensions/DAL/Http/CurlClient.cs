using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;

namespace LibreOpenAI.DAL.Http
{
    internal class CurlClient // TODO: Unit Testing
    {
        private IHttpExtensionClient? client;

        public HttpRequestHeaders DefaultRequestHeaders
        {
            get
            {
                return Client.DefaultRequestHeaders;
            }
        }

        public IHttpExtensionClient Client
        {
            get
            {
                if (client == null)
                {
                    var serviceProvider = new ServiceCollection()
                        .AddHttpClient()
                        .BuildServiceProvider();

                    IHttpClientFactory clientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
                    HttpClient client = clientFactory.CreateClient();
                    this.client = new CustomHttpExtensionClient(client);
                }

                return client;
            }
            set => client = value;
        }

        public async Task<HttpResponseMessage> CurlAsync(
            Uri url,
            string method,
            Dictionary<string, string> headers)
        {
            method = (method ?? "GET").ToUpper();

            using (HttpRequestMessage request = new HttpRequestMessage(new HttpMethod(method), url))
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }

                switch (method)
                {
                    case "DELETE":
                        return await Client.DeleteAsync(url);
                    default: // "GET":
                        return await Client.GetAsync(url);
                }
            }
        }

        public async Task<HttpResponseMessage> CurlAsync(
            Uri url,
            string method,
            Dictionary<string, string> headers,
            HttpContent content)
        {
            method = (method ?? "POST").ToUpper();

            using (HttpRequestMessage request = new HttpRequestMessage(new HttpMethod(method), url))
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }

                if (content != null)
                {
                    request.Content = content;
                }

                switch (method)
                {
                    case "PATCH":
                        return await Client.PatchAsync(url, content);
                    case "PUT":
                        return await Client.PostAsync(url, content);
                    default: // "POST":
                        return await Client.PostAsync(url, content);
                }
            }
        }
    }
}
