namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages.Conents
{
    public class RefusalContentPart : IContentType, IRefusalContentPart
    {
        public const string refusalContentType = "refusal";
        public string Type
        {
            get
            {
                return refusalContentType;
            }
        }
        public required string Refusal { get; set; }
    }
}
