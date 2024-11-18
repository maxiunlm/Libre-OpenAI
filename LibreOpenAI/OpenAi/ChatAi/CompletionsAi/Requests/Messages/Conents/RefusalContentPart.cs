namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages.Conents
{
    public class RefusalContentPart : MessageContentType, IRefusalContentPart
    {
        public const string contentType = "refusal";
        
        public RefusalContentPart(): base (contentType)
        {
        }

        public required string Refusal { get; set; }
    }
}
