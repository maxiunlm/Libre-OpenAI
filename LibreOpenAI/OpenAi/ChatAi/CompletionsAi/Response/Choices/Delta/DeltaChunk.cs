namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Delta
{
    public class DeltaChunk : IDeltaChunk
    {
        public string Role { get; set; }
        public string Content { get; set; }
        public object Refusal { get; set; }
    }
}
