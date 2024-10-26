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
            catch (HttpRequestException e) when (e.StatusCode == HttpStatusCode.InternalServerError ||
                                                  e.StatusCode == HttpStatusCode.BadGateway ||
                                                  e.StatusCode == HttpStatusCode.ServiceUnavailable ||
                                                  e.StatusCode == HttpStatusCode.GatewayTimeout)
            {
                throw new Exception("Server error from OpenAI. The service may be temporarily unavailable. Try again later.", e);
            }
            // Deserialization errors
            catch (JsonSerializationException e)
            {
                throw new Exception("Deserialization error: The API response does not match the expected structure. Check for possible changes in the API response format.", e);
            }
            catch (JsonReaderException e)
            {
                throw new Exception("JSON reading error: The JSON response format is unexpected. Check the API response.", e);
            }
            // Invalid argument exceptions
            catch (ArgumentException e)
            {
                throw new ArgumentException("Argument error: Invalid parameters in the request. Check message content or request configuration.", e);
            }
            // Timeout or cancellation errors
            catch (TaskCanceledException e)
            {
                throw new TimeoutException("Request timed out: The API request took too long to respond. Consider increasing the timeout.", e);
            }
            catch (OperationCanceledException e)
            {
                throw new OperationCanceledException("Operation canceled: The request was canceled, possibly due to a cancellation token.", e);
            }
            // Catch any other unexpected exception
            catch (Exception e)
            {
                throw new Exception("An unexpected error occurred while processing the request to the OpenAI API.", e);
            }
        }

        private void SetAuthorization()
        {
            client.DefaultRequestHeaders.Authorization = Authorization;
        }
    }
}