using Newtonsoft.Json;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages.Conents
{
    public interface IImageContentPart
    {
        /// <summary>
        /// The image_url object is Required
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty("image_url")]
        [JsonRequired]
        IImageUrlContent ImageUrl { get; set; }
    }
}