using Newtonsoft.Json;

namespace LibreOpenAIExtensions.OpenAi.ChatAi.CompletionsAi.Requests.Tools.Function
{
    public interface IFunctionsRequest
    {
        /// <summary>
        /// A description of what the function does, used by the model to choose when and how to call the function.
        /// </summary>
        [JsonProperty("description")]
        string? Description { get; set; }
        /// <summary>
        /// The name of the function to be called. (Required)
        /// </summary>
        /// <remarks>Must be a-z, A-Z, 0-9, or contain underscores and dashes. With a maximum length of 64.</remarks>
        [JsonIgnore]
        bool MustThrowNameRegexException { get; set; }
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
    }
}
