using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Usage;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response
{
    public class ChatCompletionResponse : IChatCompletionResponse
    {
        public long Created { get; set; } = DateTime.UtcNow.Ticks;
        public string Id { get; set; } = string.Empty;
        public string Object { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string? ServiceTier { get; set; }
        public string? SystemFingerprint { get; set; }
        public List<IChoiceResponse> Choices { get; set; } = new List<IChoiceResponse>();
        public IUsageResponse Usage { get; set; } = new UsageResponse();
    }
}
