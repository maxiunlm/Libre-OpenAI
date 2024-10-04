using Newtonsoft.Json;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Tools.Function
{
    public interface IFunctionToolRequest
    {
        /// <summary>
        /// A description of what the function does, used by the model to choose when and how to call the function.
        /// </summary>
        [JsonProperty("description")]
        string Description { get; set; }
        /// <summary>
        /// The name of the function to be called. Must be a-z, A-Z, 0-9, or contain underscores and dashes. (Required)
        /// </summary>
        /// <remarks>With a maximum length of 64.</remarks>
        [JsonProperty("name")]
        string Name { get; set; }
        /// <summary>
        /// The parameters the functions accepts, described as a JSON Schema object. See the guide for examples, and the JSON Schema reference for documentation about the format.
        /// </summary>
        /// <remarks>Omitting parameters defines a function with an empty parameter list.</remarks>
        /// <see cref="https://platform.openai.com/docs/guides/function-calling"/>
        /// <seealso cref="https://json-schema.org/understanding-json-schema/"/>
        [JsonProperty("parameters")]
        object? Parameters { get; set; }
        /// <summary>
        /// Whether to enable strict schema adherence when generating the function call. If set to true, the model will follow the exact schema defined in the parameters field. Learn more about Structured Outputs in the function calling guide.
        /// </summary>
        /// <remarks>Only a subset of JSON Schema is supported when strict is true.</remarks>
        /// <see cref="https://platform.openai.com/docs/api-reference/chat/docs/guides/function-calling"/>
        [JsonProperty("strict")]
        bool? Strict { get; set; }
    }
}