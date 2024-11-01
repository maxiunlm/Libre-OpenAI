using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Tools.Function;

namespace LibreOpenAIExtensions.OpenAi.ChatAi.CompletionsAi.Requests.Tools.Function
{
    public class FunctionsRequest: IFunctionsRequest
    {
        public string Description { get; set; } = string.Empty;
        public bool MustThrowNameRegexException { get; set; }
        private string name = string.Empty;
        public required string Name
        {
            get => name;
            set
            {
                name = FunctionToolRequest.GetNameValue(value, MustThrowNameRegexException);
            }
        }
        public object? Parameters { get; set; }
    }
}
