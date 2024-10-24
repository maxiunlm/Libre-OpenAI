using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.ResponseFormat.JsonSchema;
using Newtonsoft.Json;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.ResponseFormat
{
    public interface IResponseFormatRequest
    {
        [JsonIgnore]
        bool MustThrowRequiredJsonSchemaException { get; set; }
        /// <summary>
        /// 1 The type of response format being defined: text (Required)
        /// 2 The type of response format being defined: json_object (Required)
        /// 3 The type of response format being defined: json_schema (Required)
        /// </summary>
        [JsonProperty("type")]
        string Type { get; set; }
        /// <summary>
        /// 3 Only for json_schema type (Required)
        /// </summary>
        [JsonProperty("json_schema")]
        IJsonSchemaRequest? JsonSchema { get; set; }
    }
}