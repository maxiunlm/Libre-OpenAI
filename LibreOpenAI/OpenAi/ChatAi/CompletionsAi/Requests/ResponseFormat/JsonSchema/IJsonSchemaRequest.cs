using Newtonsoft.Json;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.ResponseFormat.JsonSchema
{
    public interface IJsonSchemaRequest
    {
        /// <summary>
        /// A description of what the response format is for, used by the model to determine how to respond in the format.
        /// </summary>
        [JsonProperty("description")]
        string? Description { get; set; }
        /// <summary>
        /// The name of the response format. Must be a-z, A-Z, 0-9, or contain underscores and dashes. (Required)
        /// </summary>
        /// <remarks>With a maximum length of 64.</remarks>
        [JsonProperty("name")]
        string Name { get; set; }
        /// <summary>
        /// The schema for the response format, described as a JSON Schema object.
        /// </summary>
        [JsonProperty("schema")]
        string? Schema { get; set; }
        /// <summary>
        /// Whether to enable strict schema adherence when generating the output. If set to true, the model will always follow the exact schema defined in the schema field. To learn more, read the Structured Outputs guide.
        /// </summary>
        /// <remarks>Only a subset of JSON Schema is supported when strict is true.</remarks>
        /// <see cref="https://platform.openai.com/docs/guides/structured-outputs"/>
        [JsonProperty("strict")]
        bool? Strict { get; set; }
    }
}