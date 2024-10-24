using LibreOpenAI.Exceptions;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.ResponseFormat.JsonSchema;
using Newtonsoft.Json.Schema;
using System.Data;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.ResponseFormat
{
    public class ResponseFormatRequest : IResponseFormatRequest
    {
        public const string jsonSchemaType = "json_schema";
        public bool MustThrowRequiredJsonSchemaException { get; set; }
        public required string Type { get; set; } = jsonSchemaType;
        private IJsonSchemaRequest? jsonSchema;
        public IJsonSchemaRequest? JsonSchema
        {
            get => jsonSchema;
            set
            {
                if (value == null && Type == jsonSchemaType && MustThrowRequiredJsonSchemaException)
                {
                    throw new LibreOpenAiRequiredJsonSchemaException(Type);
                }

                jsonSchema = value;
            }
        }
    }
}
