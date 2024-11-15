namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages.Conents
{
    public class ImageContentPart : IContentType, IImageContentPart
    {
        public const string imageUrlContentType = "image_url";
        public string Type
        {
            get
            {
                return imageUrlContentType;
            }
        }
        public required IImageUrlContent ImageUrl { get; set; }
    }
}
