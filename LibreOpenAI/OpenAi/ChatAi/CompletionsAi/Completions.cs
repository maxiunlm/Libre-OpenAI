using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests;
using LibreOpenAI.OpenAi.Settings;
using LibreOpenAI.DAL;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi
{
    public class Completions : ICompletions
    {
        private readonly IOpenAiSettings settings;
        private IOpenAiData openAiData;

        public Completions(IOpenAiSettings settings)
        {
            this.settings = settings;
        }

        public IOpenAiData OpenAiData
        {
            get
            {
                if (openAiData == null)
                {
                    openAiData = new OpenAiData(settings);
                }

                return openAiData;
            }
            set
            {
                openAiData = value;
            }
        }

        public async Task<IChatCompletionResponse> Create(IRequestBody request)
        {
            if (request.Stream != null && request.Stream.Value == true)
            {
                throw new ArgumentException($"If you want to create a streaming completion, you must use '{nameof(Completions)}.{nameof(CreateStream)}' instead of '{nameof(Completions)}.{nameof(Create)}'.");
            }

            IChatCompletionResponse response = await OpenAiData.GetChatGptResponse(request);
            return response;
        }

        public async Task<IChatCompletionResponse> Create(dynamic request) 
        {
            VerifyNonStreamDynamicValue(request);
            IChatCompletionResponse response = await OpenAiData.GetChatGptResponse(request);
            return response;
        }

        public async Task<IChatCompletionResponse> Create(string requestJson)
        {
            IChatCompletionResponse response = await OpenAiData.GetChatGptResponse(requestJson);
            return response;
        }

        public async Task<List<IChatCompletionChunk>> CreateStream(IRequestBody request)
        {
            request.Stream = true;
            List<IChatCompletionChunk> response = await OpenAiData.GetChatGptStreamingResponse(request);
            return response;
        }

        public async Task<List<IChatCompletionChunk>> CreateStream(dynamic request)
        {
            VerifyStreamDynamicValue(request);
            List<IChatCompletionChunk> response = await OpenAiData.GetChatGptStreamingResponse(request);
            return response;
        }

        public async Task<List<IChatCompletionChunk>> CreateStream(string requestJson)
        {
            List<IChatCompletionChunk> response = await OpenAiData.GetChatGptStreamingResponse(requestJson);
            return response;
        }

        private void VerifyNonStreamDynamicValue(dynamic request)
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

        private void VerifyStreamDynamicValue(dynamic request)
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
