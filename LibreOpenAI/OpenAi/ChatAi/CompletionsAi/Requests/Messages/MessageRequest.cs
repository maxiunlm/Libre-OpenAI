using LibreOpenAI.Exceptions;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages.Conents;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages.ToolCalls;
using Newtonsoft.Json.Linq;

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
        private object? contentObject;
        private string? oneContent;
        private MessageContentType? oneContentType = null;
        private List<string>? contentList = null;
        private List<MessageContentType>? contentTypeList = null;

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
                    ?? (object?)OneContentType
                    ?? (object?)ContentList
                    ?? (object?)ContentTypeList
                    ?? contentObject;

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
                else if (value is IMessageContentType)
                {
                    OneContentType = (MessageContentType)value;
                }
                else if (value != null && value is List<MessageContentType>)
                {
                    ContentTypeList = (List<MessageContentType>)value;
                }
                else if (value != null && (value is JObject || value is JArray))
                {
                    contentObject = value;
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
        public MessageContentType? OneContentType
        {
            get => oneContentType;
            set
            {
                CleanContents();

                if (value != null)
                {
                    oneContentType = VarifyWrongContentForRole(value.Type, value);
                }
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
        public List<MessageContentType>? ContentTypeList
        {
            get => contentTypeList;
            set
            {
                CleanContents();

                if (value != null && value.Any())
                {
                    contentTypeList = VarifyWrongContentForRole(value.First().Type, value);
                    oneContentType = SetContentValue(value.First().Type, ref contentTypeList);
                }
            }
        }

        private void CleanContents()
        {
            oneContent = null;
            oneContentType = null;
            contentList = null;
            contentTypeList = null;
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

        private T? VarifyWrongContentForRole<T>(string contentType, T value)
        {
            if (MustVerifyWrongContentForRoleException && IsThereAWrongContentForRole(contentType))
            {
                return default;
            }

            return value;
        }

        private bool IsThereAWrongContentForRole(string selectedContentType)
        {
            bool isWrong = isWrongContentForRole(false, selectedContentType, MessageContentType.textContentType, textInputContentRolesList);
            isWrong = isWrongContentForRole(isWrong, selectedContentType, MessageContentType.imageUrlContentType, imageInputContentRolesList);
            isWrong = isWrongContentForRole(isWrong, selectedContentType, MessageContentType.inputAudioContentType, audioInputContentRolesList);
            isWrong = isWrongContentForRole(isWrong, selectedContentType, MessageContentType.refusalContentType, refusalContentRolesList);

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
