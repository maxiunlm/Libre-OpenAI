
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Delta.ToolCalls.Function;
namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Delta.ToolCalls
{
    public class ToolCallsChunk : IToolCallsChunk
    {
        public int Index { get; set; }
        public string Id { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public ToolCallsFunctionChunk Function { get; set; } = new ToolCallsFunctionChunk();
    }
}
