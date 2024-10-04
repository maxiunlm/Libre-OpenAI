using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Message.ToolCalls.Function;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Message.ToolCalls
{
    public class ToolCallsResponse : IToolCallsResponse
    {
        public string Id { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public IToolCallsFunctionResponse Function { get; set; } = new ToolCallsFunctionResponse();
    }
}
