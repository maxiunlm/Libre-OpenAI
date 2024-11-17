using LibreOpenAI.Exceptions;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages.Conents;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages.ToolCalls;
using System.Collections;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages
{
    public class MessageRequest : IMessageRequest
    {
        public const string systemRole = "system";
        public const string userRole = "user";
        public const string assistantRole = "assistant";
        public const string toolRole = "tool";
        public static readonly List<string> textInputContentRolesList = new List<string>() { userRole, assistantRole };
        public static readonly List<string> imageInputContentRolesList = new List<string>() { userRole };
        public static readonly List<string> audioInputContentRolesList = new List<string>() { userRole };
        public static readonly List<string> refusalContentRolesList = new List<string>() { assistantRole };
        public static readonly List<string> requiredContentRolesList = new List<string>() { systemRole, userRole, toolRole };
        public static readonly List<string> requiredToolCallIdRolesList = new List<string>() { toolRole };
        private string? toolCallId;
        private string? oneContent;
        private TextContentPart? oneContentText = null;
        private RefusalContentPart? oneContentRefusal = null;
        private ImageContentPart? oneContentImageUrl = null;
        private AudioContentPart? oneContentInputAudio = null;
        private List<string>? contentList = null;
        private List<ImageContentPart>? contentImageUrlList = null;
        private List<AudioContentPart>? contentInputAudioList = null;
        private List<TextContentPart>? contentTextList = null;
        private List<RefusalContentPart>? contentRefusalList = null;

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
                if (value == null && requiredToolCallIdRolesList.Any(r => r == Role))
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
        public bool MustVerifyWrongContentForRoleException { get; set; }
        public bool MustThrowWrongContentForRoleException { get; set; }
        public List<ToolCallRequest>? ToolCalls { get; set; } // HACK: = [];

        public virtual object? Content
        {
            get
            {
                object? content = (object?)OneContent
                    ?? (object?)OneContentText
                    ?? (object?)OneContentRefusal
                    ?? (object?)OneContentImageUrl
                    ?? (object?)OneContentInputAudio
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
                else if (value is IContentType)
                {
                    IContentType content = (IContentType)value;

                    switch (content.Type)
                    {
                        case ImageContentPart.imageUrlContentType:
                            OneContentImageUrl = (ImageContentPart)value;
                            break;
                        case AudioContentPart.inputAudioContentType:
                            OneContentInputAudio = (AudioContentPart)value;
                            break;
                        case TextContentPart.textContentType:
                            OneContentText = (TextContentPart)value;
                            break;
                        case RefusalContentPart.refusalContentType:
                            OneContentRefusal = (RefusalContentPart)value;
                            break;
                    }
                }
                else if (value is IList)
                {
                    foreach (var content in (IList)value)
                    {
                        switch (((IContentType)content).Type)
                        {
                            case ImageContentPart.imageUrlContentType:
                                ContentImageUrlList = (List<ImageContentPart>)value;
                                break;
                            case AudioContentPart.inputAudioContentType:
                                ContentInputAudioList = (List<AudioContentPart>)value;
                                break;
                            case TextContentPart.textContentType:
                                ContentTextList = (List<TextContentPart>)value;
                                break;
                            case RefusalContentPart.refusalContentType:
                                ContentRefusalList = (List<RefusalContentPart>)value;
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
        public TextContentPart? OneContentText
        {
            get => oneContentText;
            set
            {
                CleanContents();
                oneContentText = VarifyWrongContentForRole(TextContentPart.textContentType, value);
            }
        }
        public RefusalContentPart? OneContentRefusal
        {
            get => oneContentRefusal;
            set
            {
                CleanContents();
                oneContentRefusal = VarifyWrongContentForRole(RefusalContentPart.refusalContentType, value);
            }
        }
        public ImageContentPart? OneContentImageUrl
        {
            get => oneContentImageUrl;
            set
            {
                CleanContents();
                oneContentImageUrl = VarifyWrongContentForRole(ImageContentPart.imageUrlContentType, value);
            }
        }
        public AudioContentPart? OneContentInputAudio
        {
            get => oneContentInputAudio;
            set
            {
                CleanContents();
                oneContentInputAudio = VarifyWrongContentForRole(AudioContentPart.inputAudioContentType, value);
            }
        }

        public List<string>? ContentList
        {
            get => contentList;
            set
            {
                CleanContents();
                contentList = value;
                string contentType = "List<string>";
                oneContent = SetContentValue(contentType, ref contentList);
            }
        }
        public List<ImageContentPart>? ContentImageUrlList
        {
            get => contentImageUrlList;
            set
            {
                CleanContents();
                contentImageUrlList = VarifyWrongContentForRole(ImageContentPart.imageUrlContentType, value);
                oneContentImageUrl = SetContentValue(ImageContentPart.imageUrlContentType, ref contentImageUrlList);
            }
        }
        public List<AudioContentPart>? ContentInputAudioList
        {
            get => contentInputAudioList;
            set
            {
                CleanContents();
                contentInputAudioList = VarifyWrongContentForRole(AudioContentPart.inputAudioContentType, value);
                oneContentInputAudio = SetContentValue(AudioContentPart.inputAudioContentType, ref contentInputAudioList);
            }
        }
        public List<RefusalContentPart>? ContentRefusalList
        {
            get => contentRefusalList;
            set
            {
                CleanContents();
                contentRefusalList = VarifyWrongContentForRole(RefusalContentPart.refusalContentType, value);
                oneContentRefusal = SetContentValue(RefusalContentPart.refusalContentType, ref contentRefusalList);
            }
        }
        public List<TextContentPart>? ContentTextList
        {
            get => contentTextList;
            set
            {
                CleanContents();
                contentTextList = VarifyWrongContentForRole(TextContentPart.textContentType, value);
                oneContentText = SetContentValue(TextContentPart.textContentType, ref contentTextList);
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
            if (requiredContentRolesList.Any(r => r == Role))
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

        private T? SetContentValue<T>(string contentType, ref List<T>? contentPartList)
        {
            T? result = default;

            if (contentPartList == null)
            {
                VerifyContent(contentType);
            }
            else if (contentPartList.Count() == 1)
            {
                result = contentPartList.First();
                contentPartList = null;
            }

            return result;
        }

        private T? VarifyWrongContentForRole<T>(string contentType, T? value)
        {
            if (MustVerifyWrongContentForRoleException && IsThereAWrongContentForRole(contentType))
            {
                return default;
            }

            return value;
        }

        private bool IsThereAWrongContentForRole(string selectedContentType)
        {
            bool isWrong = isWrongContentForRole(false, selectedContentType, TextContentPart.textContentType, textInputContentRolesList);
            isWrong = isWrongContentForRole(isWrong, selectedContentType, ImageContentPart.imageUrlContentType, imageInputContentRolesList);
            isWrong = isWrongContentForRole(isWrong, selectedContentType, AudioContentPart.inputAudioContentType, audioInputContentRolesList);
            isWrong = isWrongContentForRole(isWrong, selectedContentType, RefusalContentPart.refusalContentType, refusalContentRolesList);

            if (isWrong)
            {
                if (MustThrowWrongContentForRoleException)
                {
                    throw new LibreOpenAiWrongContentForException(Role, selectedContentType);
                }
                else
                {
                    CleanContents();
                    Console.WriteLine($"{DateTime.UtcNow.ToLongDateString()} WARN: The '{Role}' role is not valid for the '{selectedContentType}' type.");
                }
            }

            return isWrong;
        }

        private bool isWrongContentForRole(bool isWrong, string selectedContentType, string contentType, List<string> contentRolesList)
        {
            return isWrong || selectedContentType == contentType && !contentRolesList.Any(o => o == Role);
        }
    }
}
