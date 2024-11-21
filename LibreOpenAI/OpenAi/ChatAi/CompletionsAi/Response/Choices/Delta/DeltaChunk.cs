using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Delta.ToolCalls;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Delta
{
    public class DeltaChunk : IDeltaChunk
    {
        public string Role { get; set; }
        public string? Content { get; set; }
        public string? Refusal { get; set; }
        public int MyProperty { get; set; }
        public List<ToolCallsChunk> ToolCalls { get; set; }
    }
}
