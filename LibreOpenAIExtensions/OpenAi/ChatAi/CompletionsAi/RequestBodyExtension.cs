using LibreOpenAIExtensions.OpenAi.ChatAi.CompletionsAi.Requests;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests
{
    public class RequestBodyExtension : RequestBody, IRequestBodyExtension
    {
        public int? MaxTokens { get; set; }
    }
}
