namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages.Conents
{
    public class AudioContentPart : MessageContentType, IAudioContentPart
    {
        public const string contentType = "input_audio";

        public AudioContentPart() : base(contentType)
        {
        }

        public required IInputAudioContent InputAudio { get; set; }
    }
}
