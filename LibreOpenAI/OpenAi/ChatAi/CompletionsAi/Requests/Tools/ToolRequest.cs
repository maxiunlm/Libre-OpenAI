using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Tools.Function;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Tools
{
    public class ToolRequest : IToolRequest
    {
        public required string Type { get; set; }
        public required IFunctionToolRequest Function { get; set; }
    }
}
