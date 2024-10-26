using LibreOpenAI.DAL.Http;
using LibreOpenAI.Exceptions.OpenAI;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response;
using LibreOpenAI.OpenAi.Settings;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Authentication;

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
            // Specific OpenAI API exceptions
            catch (HttpRequestException e) when (e.StatusCode == HttpStatusCode.TooManyRequests)
            {
                throw new LibreOpenAITooManyRequestsException(e);
            }
            catch (HttpRequestException e) when (e.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new LibreOpenAiAuthenticationException(e);
            }
            catch (HttpRequestException e) when (e.StatusCode == HttpStatusCode.InternalServerError )
            {
                throw new LibreOpenAiInternalServerErrorException(e);
            }
            catch (HttpRequestException e) when (e.StatusCode == HttpStatusCode.BadGateway)
            {
                throw new LibreOpenAiBadGatewayException(e);
            }
            catch (HttpRequestException e) when (e.StatusCode == HttpStatusCode.ServiceUnavailable)
            {
                throw new LibreOpenAiServiceUnavailableException(e);
            }
            catch (HttpRequestException e) when (e.StatusCode == HttpStatusCode.GatewayTimeout)
            {
                throw new LibreOpenAiGatewayTimeoutException(e);
            }
            // Deserialization errors
            catch (JsonSerializationException e)
            {
                throw new LibreOpenAiJsonSerializationException(e);
            }
            catch (JsonReaderException e)
            {
                throw new LibreOpenAiJsonReaderException(e);
            }
            // Invalid argument exceptions
            catch (ArgumentException e)
            {
                throw new LibreOpenAiArgumentException(e);
            }
            // Timeout or cancellation errors
            catch (TaskCanceledException e)
            {
                throw new LibreOpenAiTaskCanceledException(e);
            }
            catch (OperationCanceledException e)
            {
                throw new LibreOpenAiOperationCanceledException(e);
            }
            // Catch any other unexpected exception
            catch (Exception e)
            {
                throw new LibreOpenAiUnexpectedException(e);
            }
        }

        private void SetAuthorization()
        {
            client.DefaultRequestHeaders.Authorization = Authorization;
        }
    }
}