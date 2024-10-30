using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests;
using LibreOpenAIExtensions.OpenAi.ChatAi.CompletionsAi.Requests.Tools.Function;
using Newtonsoft.Json;

namespace LibreOpenAIExtensions.OpenAi.ChatAi.CompletionsAi.Requests
{
    public interface IRequestBodyExtension : IRequestBody
    {
        /// <summary>
        /// The maximum number of tokens that can be generated in the chat completion. This value can be used to control costs for text generated via API.
        /// </summary>
        /// <remarks>
        /// This value is now deprecated in favor of max_completion_tokens, and is not compatible with o1 series models.
        /// </remarks>
        /// <see cref="https://platform.openai.com/docs/guides/reasoning"/>
        [JsonProperty("max_tokens")]
        int? MaxTokens { get; set; }
        /// <summary>
        /// Controls which (if any) function is called by the model. none means the model will not call a function and instead generates a message. auto means the model can pick between generating a message or calling a function. Specifying a particular function via {"name": "my_function"} forces the model to call that function.
        /// </summary>
        /// <remarks>'none' is the default when no functions are present.'auto' is the default if functions.</remarks>
        /// <remarks>This value is now deprecated in favor of tool_choice.</remarks>
        [JsonProperty("function_call")]
        object? FunctionCall { get; set; }
        [JsonIgnore]
        string? FunctionCallString { get; set; }
        [JsonIgnore]
        IFunctionCallRequest? FunctionCallObject { get; set; }
    }
}
