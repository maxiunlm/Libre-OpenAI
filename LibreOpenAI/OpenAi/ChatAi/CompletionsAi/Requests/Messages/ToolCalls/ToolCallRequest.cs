using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages.ToolCalls.Function;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages.ToolCalls
{
    public class ToolCallRequest : IToolCallRequest
    {
        public required string Id { get; set; }
        public required string Type { get; set; }
        public required IFunctionRequest Function { get; set; } = new FunctionRequest
        {
            Arguments = string.Empty,
            Name = string.Empty,
        };
    }
}
