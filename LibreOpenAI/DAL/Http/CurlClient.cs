using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;
using System.Text;

namespace LibreOpenAI.DAL.Http
{
    public class CurlClient : ICurlClient // TODO: Unit Testing
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
                if (client == null)
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

        public async Task<HttpResponseMessage> CurlAsync(
            Uri url,
            string method,
            Dictionary<string, string> headers)
        {
            method = string.IsNullOrWhiteSpace(method) ? "GET" : method.Trim().ToUpper();

            using (HttpRequestMessage request = new HttpRequestMessage(new HttpMethod(method), url))
            {
                foreach (var header in headers)
                {
                    if(header.Key.ToLower() == "content-type")
                    {
                        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(header.Value));
                    }
                    else
                    {
                        request.Headers.Add(header.Key, header.Value);
                    }
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
            method = string.IsNullOrWhiteSpace(method) ? "POST" : method.Trim().ToUpper();

            using (HttpRequestMessage request = new HttpRequestMessage(new HttpMethod(method), url))
            {
                foreach (var header in headers)
                {
                    if (header.Key.ToLower() == "content-type")
                    {
                        request.Content = new StringContent("{ \"key\": \"value\" }", Encoding.UTF8, header.Value);
                    }
                    else
                    {
                        request.Headers.Add(header.Key, header.Value);
                    }
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
