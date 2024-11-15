using Newtonsoft.Json;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages.Conents
{
    public interface ITextContentPart
    {
        /// <summary>
        /// The text content.
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty("text")]
        [JsonRequired]
        string Text { get; set; }
    }
}