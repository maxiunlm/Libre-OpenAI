using LibreOpenAI.DAL.Http;

namespace LibreOpenAIExtensions.OpenAi.CurlAi
{
    public class Curl : ICurl // TODO: Unit Testing
    {
        private readonly CurlClient client;

        public Curl()
        {
            client = new CurlClient();
        }

        public async Task<HttpResponseMessage> CurlAsync(
            string url,
            string method,
            Dictionary<string, string> headers)
        {
            return await CurlAsync(new Uri(url), method, headers);
        }
        public async Task<HttpResponseMessage> CurlAsync(
            string url,
            string method,
            Dictionary<string, string> headers,
            HttpContent content)
        {
            return await CurlAsync(new Uri(url), method, headers, content);
        }

        public async Task<HttpResponseMessage> CurlAsync(
            Uri url,
            string method,
            Dictionary<string, string> headers)
        {
            return await client.CurlAsync(url, method, headers);
        }
        public async Task<HttpResponseMessage> CurlAsync(
            Uri url,
            string method,
            Dictionary<string, string> headers,
            HttpContent content)
        {
            return await client.CurlAsync(url, method, headers, content);
        }
    }
}
