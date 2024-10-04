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
            IChatCompletionResponse response = await openAiData.GetChatGptResponse(request);

            return response;
        }
    }
}
