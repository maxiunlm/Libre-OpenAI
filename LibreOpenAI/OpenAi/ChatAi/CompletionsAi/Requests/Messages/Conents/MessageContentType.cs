namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages.Conents
{
    public class MessageContentType : IMessageContentType
    {
        public const string refusalContentType = "refusal";
        public const string textContentType = "text";
        public const string imageUrlContentType = "image_url";
        public const string inputAudioContentType = "input_audio";

        public required string Type { get; set; }
        public string? Refusal { get; set; }
        public string? Text { get; set; }
        public IImageUrlContent? ImageUrl { get; set; }
        public IInputAudioContent? InputAudio { get; set; }
    }
}
