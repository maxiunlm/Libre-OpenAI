using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages;
using LibreOpenAIExtensions.OpenAi.ChatAi.CompletionsAi.Requests;
using LibreOpenAIExtensions.OpenAi.ChatAi.CompletionsAi.Requests.Messages;
using LibreOpenAIExtensions.OpenAi.ChatAi.CompletionsAi.Requests.Tools.Function;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests
{
    public class RequestBodyExtension : RequestBody, IRequestBodyExtension
    {
        public const string autoFunctionCall = "auto";
        public const string noneFunctionCall = "none";

        public int? MaxTokens { get; set; }
        public List<FunctionsRequest>? Functions { get; set; }

        private string? functionCallString;
        public string? FunctionCallString
        {
            get => functionCallString;
            set
            {
                functionCallObject = null;
                functionCallString = value;
            }
        }
        private IFunctionCallRequest? functionCallObject;
        public IFunctionCallRequest? FunctionCallObject
        {
            get => functionCallObject;
            set
            {
                functionCallString = null;
                functionCallObject = value;
            }
        }
        public object? FunctionCall
        {
            get
            {
                if (FunctionCallObject != null)
                {
                    return FunctionCallObject;
                }
                else if (string.IsNullOrWhiteSpace(FunctionCallString)
                    || (FunctionCallString != autoFunctionCall
                        && FunctionCallString != noneFunctionCall
                    ))
                {
                    FunctionCallString = null;
                }

                return FunctionCallString;
            }
            set
            {
                if (value is string)
                {
                    FunctionCallString = (string?)value;  // Hack: ?? string.Empty);
                }
                else
                {
                    FunctionCallObject = (IFunctionCallRequest?)value;
                }
            }
        }
        private List<MessageRequestExtension>? messagesExtension;
        public override required List<MessageRequest> Messages
        {
            get
            {
                return (messagesExtension ?? new List<MessageRequestExtension>()).Select(o => (MessageRequest)o).ToList();
            }
            set
            {
                base.Messages = (value ?? new List<MessageRequest>()).Select(o => (new MessageRequestExtension(o) { 
                    Role = MessageRequestExtension.functionRole,
                    Name = o.Name ?? string.Empty,
                    Content = o.Content,
                }) as MessageRequest).ToList();
            }
        }
        public List<MessageRequestExtension>? MessagesExtension { get => messagesExtension; set => messagesExtension = value; }
    }
}
