using Newtonsoft.Json;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages.Conents
{
    public interface IContentType
    {
        /// <summary>
        /// The type of the content part.
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty("type")]
        [JsonRequired]
        string Type { get; }
    }
}
