using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Tools.Choise.Function;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Tools.Choise
{
    public class ToolChoiseRequest : IToolChoiseRequest
    {
        public required string Type { get; set; }
        public required IFunctionToolChoiseRequest Function { get; set; }
    }
}
