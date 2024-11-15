namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages.Conents
{
    public class TextContentPart : IContentType, ITextContentPart
    {
        public const string textContentType = "text";
        public string Type
        {
            get
            {
                return textContentType;
            }
        }
        public required string Text { get; set; }
    }
}
