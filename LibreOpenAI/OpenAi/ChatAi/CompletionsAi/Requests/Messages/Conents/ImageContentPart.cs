namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages.Conents
{
    public class ImageContentPart : MessageContentType, IImageContentPart
    {
        public const string contentType = "image_url";

        public ImageContentPart() : base(contentType)
        {
        }

        public required IImageUrlContent ImageUrl { get; set; }
    }
}
