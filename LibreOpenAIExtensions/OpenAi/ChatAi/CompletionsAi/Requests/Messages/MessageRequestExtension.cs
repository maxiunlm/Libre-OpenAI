using LibreOpenAI.Exceptions;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages;

namespace LibreOpenAIExtensions.OpenAi.ChatAi.CompletionsAi.Requests.Messages
{
    public class MessageRequestExtension : MessageRequest
    {
        public const string functionRole = "function";

        public MessageRequestExtension() { }

        public MessageRequestExtension(MessageRequest message)
        {
            MustThrowRequiredContentException = message.MustThrowRequiredContentException;
            MustThrowRequiredToolCallIdException = message.MustThrowRequiredToolCallIdException;
            Name = message.Name ?? string.Empty;
            Role = functionRole;
            Content = message.Content;
            Refusal = message.Refusal;
            ToolCallId = message.ToolCallId;
            ToolCalls = message.ToolCalls;
        }

        /// <summary>
        /// 5 The name of the function message. (Required)
        /// </summary>
        public override required string Name { get; set; } = string.Empty;
        /// <summary>
        /// 5 The role of the function message. (Required)
        /// </summary>
        public override required string Role { get; set; } = functionRole;
        /// <summary>
        /// 5 The contents of the function message. (Required)
        /// </summary>
        public override required object? Content
        {
            get
            {
                return base.Content;
            }
            set
            {
                if (value == null)
                {
                    if (MustThrowRequiredContentException)
                    {
                        throw new LibreOpenAiRequiredContentException(Role, "object");
                    }
                }

                base.Content = value;
            }
        }
    }
}
