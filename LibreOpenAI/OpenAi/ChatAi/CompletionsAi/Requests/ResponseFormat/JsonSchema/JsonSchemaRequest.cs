namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.ResponseFormat.JsonSchema
{
    public class JsonSchemaRequest : IJsonSchemaRequest
    {
        public required string Name { get; set; }
        public string? Description { get; set; } // Hack: = string.Empty;
        public string? Schema { get; set; } // Hack: = string.Empty;
        public bool? Strict { get; set; }
    }
}
