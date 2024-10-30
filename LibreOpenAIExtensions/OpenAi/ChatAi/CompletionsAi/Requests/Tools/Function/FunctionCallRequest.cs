namespace LibreOpenAIExtensions.OpenAi.ChatAi.CompletionsAi.Requests.Tools.Function
{
    public class FunctionCallRequest : IFunctionCallRequest
    {
        public required string Name { get; set; }
    }
}
