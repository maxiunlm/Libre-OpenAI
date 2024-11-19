namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages.Conents
{
    public class MessageContentType : IMessageContentType
    {
        public const string refusalContentType = "refusal";
        public const string textContentType = "text";
        public const string imageUrlContentType = "image_url";
        public const string inputAudioContentType = "input_audio";
        private static readonly List<string> validTypes = new List<string> { 
            refusalContentType, 
            textContentType, 
            imageUrlContentType, 
            inputAudioContentType 
        };
        private string type;
        private string? refusal;
        private string? text;
        private IImageUrlContent? imageUrl;
        private IInputAudioContent? inputAudio;

        public bool MustThrowArgumentException { get; set; }// TODO: Unit test

        public required string Type { 
            get => type; 
            set
            {
                if (MustThrowArgumentException && !validTypes.Any(t => t == value))
                {
                    throw new ArgumentException($"The value '{value}' mist be one of '{string.Join(", ", validTypes)}' values.");
                }

                type = value;
            }
        }
        public string? Refusal
        {
            get => Type == refusalContentType ? refusal : null;
            set => refusal = VerifyRequiredContent(value, refusalContentType, "Refusal");
        } 
        public string? Text {
            get => Type == textContentType? text: null;
            set => refusal = VerifyRequiredContent(value, textContentType, "Text");
        }
        public IImageUrlContent? ImageUrl
        {
            get => Type == imageUrlContentType ? imageUrl : null;
            set => imageUrl = VerifyRequiredContent(value, imageUrlContentType, "ImageUrl");
        }
        public IInputAudioContent? InputAudio
        {
            get => Type == inputAudioContentType ? inputAudio : null;
            set => inputAudio = VerifyRequiredContent(value, inputAudioContentType, "InputAudio");
        }

        private T VerifyRequiredContent<T>(T? value, string contentType, string contentName)
        {
            if (Type == contentType && value == null)
            {
                throw new ArgumentException($"{contentName} ismandatoru when Type is equal to '{contentType}'.");
            }

            return value;
        }
    }
}
