using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages.ToolCalls;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages
{
    public class MessageRequest : IMessageRequest
    {
        // TODO: review when every field is required (cases from 1 to 4) using the interface...
        public required string Role { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Refusal { get; set; } = string.Empty;
        public string ToolCallId { get; set; } = string.Empty;
        public List<string> Content { get; set; } = new List<string>();
        public List<IToolCallRequest> ToolCalls { get; set; } = [];
    }
}
