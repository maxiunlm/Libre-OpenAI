using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests;
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
    }
}
