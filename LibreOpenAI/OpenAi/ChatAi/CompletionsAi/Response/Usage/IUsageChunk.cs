using Newtonsoft.Json;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Usage
{
    public interface IUsageChunk
    {
        /// <summary>
        /// Number of tokens in the generated completion.
        /// </summary>
        [JsonProperty("completion_tokens")]
        int CompletionTokens { get; set; }
        /// <summary>
        /// Number of tokens in the prompt.
        /// </summary>
        [JsonProperty("prompt_tokens")]
        int PromptTokens { get; set; }
        /// <summary>
        /// Total number of tokens used in the request (prompt + completion).
        /// </summary>
        [JsonProperty("total_tokens")]
        int TotalTokens { get; set; }
    }
}