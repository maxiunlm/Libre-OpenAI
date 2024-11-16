using LibreOpenAI.Exceptions;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages.Conents;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages.ToolCalls;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages
{
    public class MessageRequest : IMessageRequest
    {
        public const string systemRole = "system";
        public const string userRole = "user";
        public const string assistantRole = "assistant";
        public const string toolRole = "tool";
        private static readonly List<string> textInputContentList = new List<string>() { userRole, assistantRole };
        private static readonly List<string> imageInputContentList = new List<string>() { userRole };
        private static readonly List<string> audioInputContentList = new List<string>() { userRole };
        private static readonly List<string> refusalContentList = new List<string>() { assistantRole };
        private static readonly List<string> requiredContentList = new List<string>() { systemRole, userRole, toolRole };
        private static readonly List<string> requiredToolCallIdList = new List<string>() { toolRole };
        private string? toolCallId;
        private string? oneContent;
        private ITextContentPart? oneContentText = null;
        private IRefusalContentPart? oneContentRefusal = null;
        private IImageContentPart? oneContentImageUrl = null;
        private IAudioContentPart? oneContentInputAudio = null;
        private List<string>? contentList = null;
        private List<IImageContentPart>? contentImageUrlList = null;
        private List<IAudioContentPart>? contentInputAudioList = null;
        private List<ITextContentPart>? contentTextList = null;
        private List<IRefusalContentPart>? contentRefusalList = null;

        public virtual required string Role { get; set; } = systemRole;
        public virtual string? Name { get; set; } // HACK:= string.Empty;
        public string? Refusal { get; set; } // HACK:= string.Empty;
        public string? ToolCallId
        {
            get
            {
                return toolCallId;
            }
            set
            {
                if (value == null && requiredToolCallIdList.Any(r => r == Role))
                {
                    if (MustThrowRequiredToolCallIdException)
                    {
                        throw new LibreOpenAiRequiredToolCallIdException(Role);
                    }
                    // Hack: 
                    //else
                    //{
                    //    toolCallId = string.Empty;
                    //}
                }

                toolCallId = value;
            }
        }
        public bool MustThrowRequiredToolCallIdException { get; set; }
        public bool MustThrowRequiredContentException { get; set; }
        public bool MustVerifyWrongContentForRoleException { get; set; } // TODO: Unit tests
        public bool MustThrowWrongContentForRoleException { get; set; } // TODO: Unit tests
        public List<IToolCallRequest>? ToolCalls { get; set; } // HACK: = [];

        public virtual object? Content
        {
            get
            {
                object? content = (object?)OneContent
                    ?? (object?)ContentList
                    ?? (object?)ContentImageUrlList
                    ?? (object?)ContentInputAudioList
                    ?? (object?)ContentRefusalList
                    ?? (object?)ContentTextList;

                return content;
            }
            set
            {
                CleanContents();

                if (value == null)
                {
                    return;
                }
                else if (value is string)
                {
                    OneContent = (string?)value;
                }
                else if (value is List<string>)
                {
                    ContentList = (List<string>)value;
                }
                else if (value is IList<IContentType>)
                {
                    foreach (IContentType content in ((IList<IContentType>)value))
                    {
                        // TODO: review Role, it's different for: system, user, assistant and tool, show warnings
                        switch (content.Type)
                        {
                            case ImageContentPart.imageUrlContentType:
                                ContentImageUrlList = (List<IImageContentPart>?)value;
                                break;
                            case AudioContentPart.inputAudioContentType:
                                ContentInputAudioList = (List<IAudioContentPart>?)value;
                                break;
                            case TextContentPart.textContentType:
                                ContentTextList = (List<ITextContentPart>?)value;
                                break;
                            case RefusalContentPart.refusalContentType:
                                ContentRefusalList = (List<IRefusalContentPart>?)value;
                                break;
                        }
                    }
                }
            }
        }
        public string? OneContent
        {
            get => oneContent;
            set
            {
                CleanContents();
                oneContent = value;
            }
        }
        public ITextContentPart? OneContentText
        {
            get => oneContentText;
            set
            {
                CleanContents();

                if (MustVerifyWrongContentForRoleException)
                {
                    VarifyWrongContentForRole(TextContentPart.textContentType);
                    return;
                }

                oneContentText = value;
            }
        }
        public IRefusalContentPart? OneContentRefusal
        {
            get => oneContentRefusal;
            set
            {
                CleanContents();

                if (MustVerifyWrongContentForRoleException)
                {
                    VarifyWrongContentForRole(RefusalContentPart.refusalContentType);
                    return;
                }

                oneContentRefusal = value;
            }
        }
        public IImageContentPart? OneContentImageUrl
        {
            get => oneContentImageUrl;
            set
            {
                CleanContents();

                if (MustVerifyWrongContentForRoleException)
                {
                    VarifyWrongContentForRole(ImageContentPart.imageUrlContentType);
                    return;
                }

                oneContentImageUrl = value;
            }
        }
        public IAudioContentPart? OneContentInputAudio
        {
            get => oneContentInputAudio;
            set
            {
                CleanContents();

                if (MustVerifyWrongContentForRoleException)
                {
                    VarifyWrongContentForRole(AudioContentPart.inputAudioContentType);
                    return;
                }

                oneContentInputAudio = value;
            }
        }
        public List<string>? ContentList
        {
            get => contentList;
            set
            {
                CleanContents();
                contentList = value;

                if (value == null)
                {
                    string contentType = "List<string>";
                    VerifyContent(contentType);
                }
                else if (value.Count() == 1)
                {
                    oneContent = value.First();
                    contentList = null;
                }
            }
        }
        public List<IImageContentPart>? ContentImageUrlList
        {
            get => contentImageUrlList;
            set
            {
                CleanContents();

                if (MustVerifyWrongContentForRoleException)
                {
                    VarifyWrongContentForRole(ImageContentPart.imageUrlContentType);
                    return;
                }

                contentImageUrlList = value;

                if (value == null)
                {
                    VerifyContent(ImageContentPart.imageUrlContentType);
                }
                else if (value.Count() == 1)
                {
                    oneContentImageUrl = value.First();
                    contentImageUrlList = null;
                }
            }
        }
        public List<IAudioContentPart>? ContentInputAudioList
        {
            get => contentInputAudioList;
            set
            {
                CleanContents();

                if (MustVerifyWrongContentForRoleException)
                {
                    VarifyWrongContentForRole(AudioContentPart.inputAudioContentType);
                    return;
                }

                contentInputAudioList = value;

                if (value == null)
                {
                    VerifyContent(AudioContentPart.inputAudioContentType);
                }
                else if (value.Count() == 1)
                {
                    oneContentInputAudio = value.First();
                    contentInputAudioList = null;
                }
            }
        }
        public List<IRefusalContentPart>? ContentRefusalList
        {
            get => contentRefusalList;
            set
            {
                CleanContents();

                if (MustVerifyWrongContentForRoleException)
                {
                    VarifyWrongContentForRole(RefusalContentPart.refusalContentType);
                    return;
                }

                contentRefusalList = value;

                if (value == null)
                {
                    VerifyContent(RefusalContentPart.refusalContentType);
                }
                else if (value.Count() == 1)
                {
                    oneContentRefusal = value.First();
                    contentRefusalList = null;
                }
            }
        }
        public List<ITextContentPart>? ContentTextList
        {
            get => contentTextList;
            set
            {
                CleanContents();

                if (MustVerifyWrongContentForRoleException)
                {
                    VarifyWrongContentForRole(TextContentPart.textContentType);
                    return;
                }

                contentTextList = value;

                if (value == null)
                {
                    VerifyContent(TextContentPart.textContentType);
                }
                else if (value.Count() == 1)
                {
                    oneContentText = value.First();
                    contentTextList = null;
                }
            }
        }

        private void CleanContents()
        {
            oneContent = null;
            oneContentImageUrl = null;
            oneContentInputAudio = null;
            oneContentText = null;
            oneContentRefusal = null;
            contentList = null;
            contentImageUrlList = null;
            contentInputAudioList = null;
            contentRefusalList = null;
            contentTextList = null;
        }

        private void VerifyContent(string contentType)
        {
            if (requiredContentList.Any(r => r == Role))
            {
                if (MustThrowRequiredContentException)
                {
                    throw new LibreOpenAiRequiredContentException(Role, contentType);
                }
                // HACK: 
                //else if (!ToolCalls.Any()) // NOTE:  function_call is deprecated
                //{
                //    contentList = new List<string>();
                //    return;
                //}
            }
        }

        private void VarifyWrongContentForRole(string selectedContentType)
        {
            if (MustThrowWrongContentForRoleException)
            {
                bool isWrong = VarifyWrongContentForRole(false, selectedContentType, TextContentPart.textContentType, textInputContentList);
                isWrong = VarifyWrongContentForRole(isWrong, selectedContentType, ImageContentPart.imageUrlContentType, imageInputContentList);
                isWrong = VarifyWrongContentForRole(isWrong, selectedContentType, AudioContentPart.inputAudioContentType, audioInputContentList);
                isWrong = VarifyWrongContentForRole(isWrong, selectedContentType, RefusalContentPart.refusalContentType, refusalContentList);

                if (isWrong)
                {
                    throw new LibreOpenAiWrongContentForException(Role, selectedContentType);
                }
            }
        }

        private bool VarifyWrongContentForRole(bool isWrong, string selectedContentType, string contentType, List<string> contentList)
        {
            return isWrong || selectedContentType == contentType && !contentList.Any(o => o == Role);
        }
    }
}
