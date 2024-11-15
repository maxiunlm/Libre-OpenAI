namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages.Conents
{
    public class InputAudioContent : IInputAudioContent
    {
        public required string Data { get; set; }
        public required string Format { get; set; }
    }
}
