using LibreOpenAI.OpenAi.ChatAi.CompletionsAi;
using Newtonsoft.Json;

namespace LibreOpenAI.OpenAi.ChatAi
{
    /// <summary>
    /// Given a list of messages comprising a conversation, the model will return a response.
    /// </summary>
    /// <see cref="https://platform.openai.com/docs/api-reference/chat"/>
    /// <seealso cref="https://platform.openai.com/docs/guides/text-generation"/>
    public interface IChat
    {
        /// <summary>
        /// To use one of these models via the OpenAI API, you’ll send a request to the Chat Completions API containing the inputs and your API key, and receive a response containing the model’s output.
        /// </summary>
        [JsonProperty("completions")]
        ICompletions Completions { get; set; }
    }
}