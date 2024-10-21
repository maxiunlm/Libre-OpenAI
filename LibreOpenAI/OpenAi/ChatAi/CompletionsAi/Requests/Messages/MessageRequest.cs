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
        // TODO: review when every field is required (cases from 1 to 4) using the interface...
        public required string Role { get; set; } = systemRole;
        public string Name { get; set; } = string.Empty;
        public string Refusal { get; set; } = string.Empty;
        public string ToolCallId { get; set; } = string.Empty;
        public bool MustThrowRequiredContentException { get; set; }
        private List<string>? content = null;
        public List<string>? Content { 
            get
            {
                if (content == null && requiredContentList.Any(r => r == Role))
                {
                    if (MustThrowRequiredContentException)
                    {
                        throw new LibreOpenAiRequiredContentException(Role);
                    }
                    else if(!ToolCalls.Any()) // NOTE:  function_call is deprecated
                    {
                        content = new List<string>();
                    }
                }

                return content;
            }
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
