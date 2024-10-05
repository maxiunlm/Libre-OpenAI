using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Usage.CompletionTokensDetails;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Usage
{
    public class UsageResponse : IUsageResponse
    {
        public int CompletionTokens { get; set; }
        public int PromptTokens { get; set; }
        public int TotalTokens { get; set; }
        public CompletionTokensDetailsResponse CompletionTokensDetails { get; set; } = new CompletionTokensDetailsResponse();
    }
}
