namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages.Conents
{
    public class ImageUrlContent : IImageUrlContent
    {
        public required string Url { get; set; }
        public string? Detail { get; set; }
    }
}
