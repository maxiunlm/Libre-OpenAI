using Newtonsoft.Json;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages.Conents
{
    public interface IAudioContentPart
    {
        /// <summary>
        /// The input_audio object is Required
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty("input_audio")]
        [JsonRequired]
        IInputAudioContent InputAudio { get; set; }
    }
}