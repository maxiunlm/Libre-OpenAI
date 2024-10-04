namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Tools.Function
{
    public class FunctionToolRequest : IFunctionToolRequest
    {
        public string Description { get; set; } = string.Empty;
        public required string Name { get; set; }
        public object? Parameters { get; set; }
        public bool? Strict { get; set; }
    }
}
