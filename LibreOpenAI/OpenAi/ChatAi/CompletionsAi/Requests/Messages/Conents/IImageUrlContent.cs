using Newtonsoft.Json;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages.Conents
{
    public interface IImageUrlContent
    {
        /// <summary>
        /// Specifies the detail level of the image.Learn more in the Vision guide.
        /// </summary>
        /// <remarks>Optional - Defaults to auto</remarks>
        /// <see cref="https://platform.openai.com/docs/guides/vision#low-or-high-fidelity-image-understanding"/>
        [JsonProperty("detail")]
        string? Detail { get; set; }
        /// <summary>
        /// Either a URL of the image or the base64 encoded image data.
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty("url")]
        [JsonRequired]
        string Url { get; set; }
    }
}