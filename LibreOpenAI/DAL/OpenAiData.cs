using LibreOpenAI.DAL.Http;
using LibreOpenAI.Exceptions.OpenAI;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response;
using LibreOpenAI.OpenAi.Settings;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace LibreOpenAI.DAL
{
    public class OpenAiData : IOpenAiData
    {
        public static readonly JsonSerializerSettings jsonSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            // DefaultValueHandling = DefaultValueHandling.Ignore
        };
        private IHttpClientAi? client;
        private AuthenticationHeaderValue? authorization;
        private readonly IOpenAiSettings settings;

        public OpenAiData()
        {
            settings = new OpenAiSettings();
        }

        public OpenAiData(IOpenAiSettings settings)
        {
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
                    authorization = new AuthenticationHeaderValue("Bearer", settings.OpenAiApiKey);
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
            string requestJson = JsonConvert.SerializeObject(request, jsonSettings);
            IChatCompletionResponse result = await GetChatGptResponse(requestJson);

            return result;
        }

        public async Task<IChatCompletionResponse> GetChatGptResponse(dynamic request)
        {
            string requestJson = JsonConvert.SerializeObject(request, jsonSettings);
            IChatCompletionResponse result = await GetChatGptResponse(requestJson);

            return result;
        }

        public async Task<IChatCompletionResponse> GetChatGptResponse(string requestJson)
        {
            string responseBody = await GetChatGptResponseJson(requestJson);
            ChatCompletionResponse result = JsonConvert.DeserializeObject<ChatCompletionResponse>(responseBody) ?? new ChatCompletionResponse();

            return result;
        }

        public async Task<dynamic> GetChatGptResponseDynamic(IRequestBody request)
        {
            string requestJson = JsonConvert.SerializeObject(request, jsonSettings);
            dynamic result = await GetChatGptResponseDynamic(requestJson);

            return result;
        }

        public async Task<dynamic> GetChatGptResponseDynamic(dynamic request)
        {
            string requestJson = JsonConvert.SerializeObject(request, jsonSettings);
            dynamic result = await GetChatGptResponseDynamic(requestJson);

            return result;
        }

        public async Task<dynamic> GetChatGptResponseDynamic(string requestJson)
        {
            string responseBody = await GetChatGptResponseJson(requestJson);
            dynamic result = JToken.Parse(responseBody);

            return result;
        }

        public async Task<string> GetChatGptResponseJson(IRequestBody request)
        {
            string requestJson = JsonConvert.SerializeObject(request, jsonSettings);
            string responseBody = await GetChatGptResponseJson(requestJson);

            return responseBody;
        }

        public async Task<string> GetChatGptResponseJson(dynamic request)
        {
            string requestJson = JsonConvert.SerializeObject(request, jsonSettings);
            string responseBody = await GetChatGptResponseJson(requestJson);

            return responseBody;
        }

        public async Task<string> GetChatGptResponseJson(string requestJson)
        {
            try
            {
                string responseBody = string.Empty;
                StringContent content = new StringContent(requestJson, settings.Encoding, settings.MediaType);
                HttpResponseMessage response = await Client.PostAsync(settings.OpenAiUrl, content);

                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();

                return responseBody;
                //return null;
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
            catch (HttpRequestException e) when (e.StatusCode == HttpStatusCode.InternalServerError)
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

        public async Task<List<IChatCompletionChunk>> GetChatGptStreamingResponse(IRequestBody request)
        {
            string requestJson = JsonConvert.SerializeObject(request, jsonSettings);
            List<IChatCompletionChunk> result = await GetChatGptStreamingResponse(requestJson);

            return result;
        }

        public async Task<List<IChatCompletionChunk>> GetChatGptStreamingResponse(dynamic request)
        {
            string requestJson = JsonConvert.SerializeObject(request, jsonSettings);
            List<IChatCompletionChunk> result = await GetChatGptStreamingResponse(requestJson);

            return result;
        }

        public async Task<List<IChatCompletionChunk>> GetChatGptStreamingResponse(string requestJson)
        {
            string responseBody = await GetChatGptStreamingResponseJson(requestJson, false);
            List<ChatCompletionChunk> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<ChatCompletionChunk>>(responseBody) ?? new List<ChatCompletionChunk>();
            }
            catch (Exception ex)
            {
                result = DeserializeJsonData(responseBody);
                Console.Error.WriteLine($"WARNIG: {ex.Message}\n{(ex.StackTrace != null ? ex.StackTrace.ToString() : string.Empty)}");
                Exception? innerException = ex.InnerException;

                while (innerException != null)
                {
                    Console.Error.WriteLine($"InnerException: {innerException.Message}\n{(innerException.StackTrace != null ? innerException.StackTrace.ToString() : string.Empty)}");
                    innerException = innerException.InnerException;
                }
            }

            return result.Select(o => (IChatCompletionChunk)o).ToList();
        }

        public async Task<dynamic> GetChatGptStreamingResponseDynamic(IRequestBody request)
        {
            string requestJson = JsonConvert.SerializeObject(request, jsonSettings);
            string responseBody = await GetChatGptStreamingResponseJson(requestJson, false);

            dynamic result = JsonConvert.DeserializeObject(responseBody);

            return result;
        }

        public async Task<dynamic> GetChatGptStreamingResponseDynamic(dynamic request)
        {
            string requestJson = JsonConvert.SerializeObject(request, jsonSettings);
            string responseBody = await GetChatGptStreamingResponseJson(requestJson, false);
            dynamic result = JsonConvert.DeserializeObject(responseBody);

            return result;
        }

        public async Task<dynamic> GetChatGptStreamingResponseDynamic(string requestJson)
        {
            string responseBody = await GetChatGptStreamingResponseJson(requestJson, false);
            dynamic result = JsonConvert.DeserializeObject(responseBody);

            return result;
        }

        public async Task<string> GetChatGptStreamingResponseJson(IRequestBody request, bool raw)
        {
            string requestJson = JsonConvert.SerializeObject(request, jsonSettings);
            string responseBody = await GetChatGptStreamingResponseJson(requestJson, raw);

            return responseBody;
        }

        public async Task<string> GetChatGptStreamingResponseJson(dynamic request, bool raw)
        {
            string requestJson = JsonConvert.SerializeObject(request, jsonSettings);
            string responseBody = await GetChatGptStreamingResponseJson(requestJson, raw);

            return responseBody;
        }

        public async Task<string> GetChatGptStreamingResponseJson(string requestJson, bool raw)
        {
            string responseBody = string.Empty;

            try
            {
                StringContent content = new StringContent(requestJson, settings.Encoding, settings.MediaType);
                HttpResponseMessage response = await Client.PostAsync(settings.OpenAiUrl, content);

                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();

                if (raw)
                {
                    return responseBody;
                }

                string json = responseBody
                    .Replace("\n", string.Empty)
                    .Replace("\r", string.Empty)
                    .Replace("data:[DONE]", "]")
                    .Replace("data: [DONE]", "]")
                    .Replace("}data:", "},")
                    .Replace("data:", "[");

                return json;
                //return null;
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
            catch (HttpRequestException e) when (e.StatusCode == HttpStatusCode.InternalServerError)
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

        /// <summary>
        /// Deserializes a JSON string containing multiple 'data:' prefixed objects into a list of ChatCompletionChunk objects.
        /// </summary>
        /// <param name="rawData">The raw JSON string.</param>
        /// <returns>A list of deserialized ChatCompletionResponse objects.</returns>
        private List<ChatCompletionChunk> DeserializeJsonData(string rawData)
        {
            // Regular expression to match each JSON block prefixed by "data:"
            var regex = new Regex(@"data:\s*(\{.*?\})(?=\s*data:|\s*\[DONE\])", RegexOptions.Singleline);

            // Find matches in the raw data
            var matches = regex.Matches(rawData);

            // List to store deserialized objects
            var result = new List<ChatCompletionChunk>();

            // Iterate over each match and deserialize it
            foreach (Match match in matches)
            {
                string jsonObject = match.Groups[1].Value; // Extract the JSON part
                try
                {
                    // Deserialize the JSON string into a IChatCompletionChunk object
                    var chunk = JsonConvert.DeserializeObject<ChatCompletionChunk>(jsonObject);
                    if (chunk != null)
                    {
                        result.Add(chunk); // Add to the result list
                    }
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Error deserializing JSON object: {ex.Message}");
                }
            }

            return result;
        }

        private void SetAuthorization()
        {
            client.DefaultRequestHeaders.Authorization = Authorization;
        }
    }
}