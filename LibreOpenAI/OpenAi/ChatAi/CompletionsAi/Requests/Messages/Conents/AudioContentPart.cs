namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages.Conents
{
    public class AudioContentPart : IContentType, IAudioContentPart
    {
        public const string inputAudioContentType = "input_audio";
        public string Type
        {
            get
            {
                return inputAudioContentType;
            }
        }
        public required IInputAudioContent InputAudio { get; set; }
    }
}
