using LibreOpenAI.OpenAi.ChatAi;
using Newtonsoft.Json;

namespace LibreOpenAI.OpenAi
{
    /// <summary>
    /// Libre C# version
    /// </summary>
    /// <see cref="https://platform.openai.com/docs/api-reference/introduction"/>
    public interface IOpenAI
    {
        /// <summary>
        /// Given a list of messages comprising a conversation, the model will return a response.
        /// </summary>
        [JsonProperty("chat")]
        IChat Chat { get; set; }
    }
}