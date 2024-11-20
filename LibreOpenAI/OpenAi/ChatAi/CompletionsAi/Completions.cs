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

        public IOpenAiData OpenAiData { 
            get
            {
                if(openAiData == null)
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
            if(request.Stream != null && request.Stream.Value == true)
            {
                throw new ArgumentException($"If you want to create a streaming completion, you must use '{nameof(Completions)}.{nameof(CreateStream)}' instead of '{nameof(Completions)}.{nameof(Create)}'.");
            }

            IChatCompletionResponse response = await OpenAiData.GetChatGptResponse(request);

            return response;
        }

        public async Task<List<IChatCompletionChunk>> CreateStream(IRequestBody request)
        {
            request.Stream = true;
            List<IChatCompletionChunk> response = await OpenAiData.GetChatGptStreamingResponse(request);

            return response;
        }
    }
}
