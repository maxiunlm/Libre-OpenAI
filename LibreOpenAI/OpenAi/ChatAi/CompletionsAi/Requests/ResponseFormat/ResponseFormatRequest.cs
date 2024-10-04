using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.ResponseFormat.JsonSchema;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.ResponseFormat
{
    public class ResponseFormatRequest : IResponseFormatRequest
    {
        // TODO: review when Json_schema is required (see case 3)
        public required string Type { get; set; }
        public IJsonSchemaRequest JsonSchema { get; set; } = new JsonSchemaRequest { Name = string.Empty };
    }
}
