namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages.Conents
{
    public class MessageContentType : IContentType
    {
        private readonly string type;

        public MessageContentType(string type)
        {
            this.type = type;
        }

        public string Type
        {
            get
            {
                return type;
            }
        }
    }
}
