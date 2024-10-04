using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Message.ToolCalls;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Message
{
    public class MessageChoiseResponse : IMessageChoiseResponse
    {
        public string Role { get; set; } = string.Empty;
        public string? Content { get; set; }
        public string? Refusal { get; set; }
        public List<IToolCallsResponse> ToolCalls { get; set; } = new List<IToolCallsResponse>();
    }
}
