using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Logprobs.Content;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Logprobs.Refusal;
using Newtonsoft.Json;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Logprobs
{
    public interface ILogprobsChoiseResponse
    {
        /// <summary>
        /// A list of message content tokens with log probability information.
        /// </summary>
        [JsonProperty("content")]
        List<ContentLogprobsChoiseResponse> Content { get; set; }
        /// <summary>
        /// A list of message refusal tokens with log probability information.
        /// </summary>
        [JsonProperty("refusal")]
        List<RefusalLogprobsChoiseResponse> Refusal { get; set; }
    }
}