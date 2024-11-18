namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages.Conents
{
    public class TextContentPart : MessageContentType, ITextContentPart
    {
        public const string contentType = "text";

        public TextContentPart() : base(contentType)
        {
        }

        public required string Text { get; set; }
    }
}
