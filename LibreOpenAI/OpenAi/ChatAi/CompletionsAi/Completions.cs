using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests;
using LibreOpenAI.OpenAi.Settings;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using LibreOpenAI.Base.Creation;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi
{
    public class Completions : CreationBase, ICompletions
    {
        public Completions(IOpenAiSettings settings) : base(settings, settings.OpenAiUrlCompletions)
        {
        }

        public async Task<IChatCompletionResponse> Create(IRequestBody request)
        {
            if (request.Stream != null && request.Stream.Value == true)
            {
                throw new ArgumentException($"If you want to create a streaming completion, you must use '{nameof(Completions)}.{nameof(CreateStream)}' instead of '{nameof(Completions)}.{nameof(Create)}'.");
            }

            string requestJson = JsonConvert.SerializeObject(request, jsonSettings);
            IChatCompletionResponse response = await Create(requestJson);
            return response;
        }

        public async Task<IChatCompletionResponse> Create(dynamic request)
        {
            VerifyNonStreamJTokenValue(request);
            string requestJson = JsonConvert.SerializeObject(request, jsonSettings);
            IChatCompletionResponse response = await Create(requestJson);
            return response;
        }

        public async Task<IChatCompletionResponse> Create(string requestJson)
        {
            string responseBody = await CreateJson(requestJson);
            IChatCompletionResponse response = JsonConvert.DeserializeObject<ChatCompletionResponse>(responseBody) ?? new ChatCompletionResponse();
            return response;
        }

        public async Task<dynamic> CreateDynamic(IRequestBody request)
        {
            if (request.Stream != null && request.Stream.Value == true)
            {
                throw new ArgumentException($"If you want to create a streaming completion, you must use '{nameof(Completions)}.{nameof(CreateStream)}' instead of '{nameof(Completions)}.{nameof(Create)}'.");
            }

            string requestJson = JsonConvert.SerializeObject(request, jsonSettings);
            dynamic response = await CreateDynamic(requestJson);
            return response;
        }

        public async Task<string> CreateJson(IRequestBody request)
        {
            if (request.Stream != null && request.Stream.Value == true)
            {
                throw new ArgumentException($"If you want to create a streaming completion, you must use '{nameof(Completions)}.{nameof(CreateStream)}' instead of '{nameof(Completions)}.{nameof(Create)}'.");
            }

            string requestJson = JsonConvert.SerializeObject(request, jsonSettings);
            string response = await CreateJson(requestJson);
            return response;
        }

        public async Task<List<IChatCompletionChunk>> CreateStream(IRequestBody request)
        {
            request.Stream = true;
            string requestJson = JsonConvert.SerializeObject(request, jsonSettings);
            List<IChatCompletionChunk> response = await CreateStream(requestJson);
            return response;
        }

        public async Task<List<IChatCompletionChunk>> CreateStream(dynamic request)
        {
            VerifyStreamJTokenValue(request);
            string requestJson = JsonConvert.SerializeObject(request, jsonSettings);
            List<IChatCompletionChunk> response = await CreateStream(requestJson);
            return response;
        }

        public async Task<List<IChatCompletionChunk>> CreateStream(string requestJson)
        {
            List<IChatCompletionChunk> response = await OpenAiData.PostChatGptStreamingResponse(requestJson);
            return response;
        }

        public async Task<dynamic> CreateStreamDynamic(IRequestBody request)
        {
            request.Stream = true; 
            string requestJson = JsonConvert.SerializeObject(request, jsonSettings);
            dynamic response = await CreateStreamDynamic(requestJson);
            return response;
        }

        public async Task<dynamic> CreateStreamDynamic(dynamic request)
        {
            VerifyStreamJTokenValue(request);
            string requestJson = JsonConvert.SerializeObject(request, jsonSettings);
            dynamic response = await CreateStreamDynamic(requestJson);
            return response;
        }

        public async Task<dynamic> CreateStreamDynamic(string requestJson)
        {
            string responseBody = await CreateStreamJson(requestJson);
            dynamic response = JToken.Parse(responseBody);
            return response;
        }

        public async Task<string> CreateStreamJson(IRequestBody request, bool raw = false)
        {
            request.Stream = true;
            string requestJson = JsonConvert.SerializeObject(request, jsonSettings);
            string responseBody = await CreateStreamJson(requestJson, raw);
            return responseBody;
        }

        public async Task<string> CreateStreamJson(dynamic request, bool raw = false)
        {
            VerifyStreamJTokenValue(request); 
            string requestJson = JsonConvert.SerializeObject(request, jsonSettings);
            string responseBody = await CreateStreamJson(requestJson, raw);
            return responseBody;
        }

        public async Task<string> CreateStreamJson(string requestJson, bool raw = false)
        {
            string responseBody = await OpenAiData.PostChatGptStreamingResponseJson(requestJson, raw);
            return responseBody;
        }

        private void VerifyNonStreamJTokenValue(dynamic request)
        {
            var objType = request.GetType();
            var property = objType.GetProperty("stream")
                ?? objType.GetField("stream")
                ?? objType.GetProperty("Stream")
                ?? objType.GetField("Stream");

            if (property != null)
            {
                var value = property.GetValue(request);

                if (value is bool boolValue && boolValue)
                {
                    throw new ArgumentException($"If you want to create a streaming completion, you must use '{nameof(Completions)}.{nameof(CreateStream)}' instead of '{nameof(Completions)}.{nameof(Create)}'.");
                }
            }
        }

        private void VerifyStreamJTokenValue(dynamic request)
        {
            var objType = request.GetType();
            var property = objType.GetProperty("stream")
                ?? objType.GetField("stream")
                ?? objType.GetProperty("Stream")
                ?? objType.GetField("Stream");

            if (property != null)
            {
                var value = property.GetValue(request);

                if (value is bool boolValue && !boolValue)
                {
                    throw new ArgumentException($"If you want to create a streaming completion, you must use set 'stream' attrinute to 'true'.");
                }
            }
        }
    }
}
