namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Usage
{
    public class UsageChunk : IUsageChunk
    {
        public int CompletionTokens { get; set; }
        public int PromptTokens { get; set; }
        public int TotalTokens { get; set; }
    }
}
