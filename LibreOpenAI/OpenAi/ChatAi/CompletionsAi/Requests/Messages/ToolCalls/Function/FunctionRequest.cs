namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages.ToolCalls.Function
{
    public class FunctionRequest : IFunctionRequest
    {
        public required string Name { get; set; }
        public required string Arguments { get; set; }
    }
}
