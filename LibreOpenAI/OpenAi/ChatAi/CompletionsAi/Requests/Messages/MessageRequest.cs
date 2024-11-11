using LibreOpenAI.Exceptions;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages.ToolCalls;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages
{
    public class MessageRequest : IMessageRequest
    {
        public const string systemRole = "system";
        public const string userRole = "user";
        public const string assistantRole = "assistant";
        public const string toolRole = "tool";
        private static readonly List<string> requiredContentList = new List<string>() { systemRole, userRole, toolRole };
        private static readonly List<string> requiredToolCallIdList = new List<string>() { toolRole };
        public virtual required string Role { get; set; } = systemRole;
        public virtual string? Name { get; set; } // HACK:= string.Empty;
        public string? Refusal { get; set; } // HACK:= string.Empty;
        public bool MustThrowRequiredToolCallIdException { get; set; }
        private string? toolCallId;
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
        public bool MustThrowRequiredContentException { get; set; }
        private string? oneContent;
        public string? OneContent
        {
            get => oneContent;
            set
            {
                contentList = null;
                oneContent = value;
            }
        }
        private List<string>? contentList = null;
        public List<string>? ContentList
        {
            get => contentList;
            set
            {
                oneContent = null;
                contentList = value;

                if (value == null)
                {
                    if (requiredContentList.Any(r => r == Role))
                    {
                        if (MustThrowRequiredContentException)
                        {
                            throw new LibreOpenAiRequiredContentException(Role);
                        }
                        // HACK: 
                        //else if (!ToolCalls.Any()) // NOTE:  function_call is deprecated
                        //{
                        //    contentList = new List<string>();
                        //    return;
                        //}
                    }
                }
                else if (value.Count() == 1)
                {
                    oneContent = value.First();
                    contentList = null;
                }
            }
        }
        public virtual object? Content
        {
            get
            {
                object? content = ContentList;

                if (OneContent != null)
                {
                    content = OneContent;
                }

                return content;
            }
            set
            {
                if (value == null)
                {
                    oneContent = null;
                    contentList = null;
                }
                else if (value is string)
                {
                    contentList = null;
                    oneContent = (string?)value;
                }
                else
                {
                    oneContent = null;
                    ContentList = (List<string>?)value;
                }
            }
        }
        public List<IToolCallRequest>? ToolCalls { get; set; } // HACK: = [];
    }
}
