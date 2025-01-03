using LibreOpenAI.DAL.Http;
using LibreOpenAI.Exceptions.OpenAI;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response;
using LibreOpenAI.OpenAi.Settings;
using Newtonsoft.Json;
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

        public async Task<string> PostChatGptResponseJson(string requestJson, Uri url)
        {
            try
            {
                string responseBody = string.Empty;
                HttpResponseMessage response;

                if (string.IsNullOrWhiteSpace(requestJson))
                {
                    response = await Client.PostAsync(url);
                }
                else
                {
                    StringContent content = new StringContent(requestJson, settings.Encoding, settings.MediaType);
                    response = await Client.PostAsync(url, content);
                }

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

        public async Task<string> GetChatGptResponseJson(Uri url)
        {
            try
            {
                string responseBody = string.Empty;
                HttpResponseMessage response = await Client.GetAsync(url);

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
        public async Task<List<IChatCompletionChunk>> PostChatGptStreamingResponse(string requestJson)
        {
            string responseBody = await PostChatGptStreamingResponseJson(requestJson, false);
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

        public async Task<string> PostChatGptStreamingResponseJson(string requestJson, bool raw)
        {
            string responseBody = string.Empty;

            try
            {
                StringContent content = new StringContent(requestJson, settings.Encoding, settings.MediaType);
                HttpResponseMessage response = await Client.PostAsync(settings.OpenAiUrlCompletions, content);

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