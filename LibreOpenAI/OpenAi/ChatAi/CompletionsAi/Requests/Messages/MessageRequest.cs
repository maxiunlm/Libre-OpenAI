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
        public virtual string Name { get; set; } = string.Empty;
        public string Refusal { get; set; } = string.Empty;
        public bool MustThrowRequiredToolCallIdException { get; set; }
        private string? toolCallId;
        public string? ToolCallId { 
            get
            {
                return toolCallId;
            }
            set
            {
                if(value == null && requiredToolCallIdList.Any(r => r == Role))
                {
                    if (MustThrowRequiredToolCallIdException)
                    {
                        throw new LibreOpenAiRequiredToolCallIdException(Role);
                    }
                    else
                    {
                        toolCallId = string.Empty;
                    }
                }

                toolCallId = value;
            }
        }
        public bool MustThrowRequiredContentException { get; set; }
        protected List<string>? content = null;
        public virtual List<string>? Content
        {
            get => content;
            set
            {
                if (value == null && requiredContentList.Any(r => r == Role))
                {
                    if (MustThrowRequiredContentException)
                    {
                        throw new LibreOpenAiRequiredContentException(Role);
                    }
                    else if (!ToolCalls.Any()) // NOTE:  function_call is deprecated
                    {
                        content = new List<string>();
                        return;
                    }
                }

                content = value;
            }
        }
        public List<IToolCallRequest> ToolCalls { get; set; } = [];
    }
}
