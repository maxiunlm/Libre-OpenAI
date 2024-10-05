using LibreOpenAI.DAL.Http;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response;
using LibreOpenAI.OpenAi.Settings;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace LibreOpenAI.DAL
{
    public class OpenAiData : IOpenAiData
    {
        private IHttpClientAi client;
        private AuthenticationHeaderValue authorization;
        private readonly string apiKey;
        private readonly IOpenAiSettings settings;

        public OpenAiData()
        {
            apiKey = Environment.GetEnvironmentVariable("LIBRE_OPEN_AI_API_KEY") ?? string.Empty;
            settings = new OpenAiSettings();
        }

        public OpenAiData(IOpenAiSettings settings)
        {
            apiKey = Environment.GetEnvironmentVariable("LIBRE_OPEN_AI_API_KEY") ?? string.Empty;
            this.settings = settings ?? new OpenAiSettings();
        }

        public IHttpClientAi Client
        {
            get
            {
                if (client == null)
                {
                    client = new HttpClientAi();
                    SetAuthorization();
                }

                return client;
            }
            set
            {
                client = value;
            }
        }

        public AuthenticationHeaderValue Authorization
        {
            get
            {
                if (authorization == null)
                {
                    authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                }

                return authorization;
            }
            set
            {
                authorization = value;
            }
        }

        public async Task<IChatCompletionResponse> GetChatGptResponse(IRequestBody request)
        {
            string responseBody = string.Empty;
            string requestJson = JsonConvert.SerializeObject(request);

            try
            {
                StringContent content = new StringContent(requestJson, settings.Encoding, settings.MediaType);
                HttpResponseMessage response = await Client.PostAsync(settings.OpenAiUrl, content);

                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();

                ChatCompletionResponse result = JsonConvert.DeserializeObject<ChatCompletionResponse>(responseBody) ?? new ChatCompletionResponse();

                return result;
            }
            catch (HttpRequestException e)
            {
                throw new Exception($"[ERROR (1)] IChatGptBase.GetGptResponse [requestJson]: {requestJson}", e);
            }
            catch (Exception e)
            {
                throw new Exception($"[ERROR (2)] IChatGptBase.GetGptResponse [requestJson]: {requestJson}", e);
            }
        }

        private void SetAuthorization()
        {
            client.DefaultRequestHeaders.Authorization = authorization;
        }
    }
}