using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Tools.Function;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Tools
{
    public class ToolRequest : IToolRequest
    {
        public const string defaultType = "function";
        public required string Type { get; set; } = defaultType;
        public required FunctionToolRequest Function { get; set; }
    }
}
