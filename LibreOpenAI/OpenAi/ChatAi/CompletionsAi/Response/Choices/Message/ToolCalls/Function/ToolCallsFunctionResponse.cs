namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Message.ToolCalls.Function
{
    public class ToolCallsFunctionResponse : IToolCallsFunctionResponse
    {
        public string Name { get; set; } = string.Empty;
        public string Arguments { get; set; } = string.Empty;
    }
}
