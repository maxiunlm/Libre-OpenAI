using Newtonsoft.Json;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages.Conents
{
    public interface IInputAudioContent
    {
        /// <summary>
        /// Base64 encoded audio data.
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty("data")]
        [JsonRequired]
        string Data { get; set; }
        /// <summary>
        /// The format of the encoded audio data. Currently supports "wav" and "mp3".
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty("format")]
        [JsonRequired]
        string Format { get; set; }
    }
}