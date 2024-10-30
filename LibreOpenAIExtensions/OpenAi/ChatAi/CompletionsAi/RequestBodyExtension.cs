using LibreOpenAIExtensions.OpenAi.ChatAi.CompletionsAi.Requests;
using LibreOpenAIExtensions.OpenAi.ChatAi.CompletionsAi.Requests.Tools.Function;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests
{
    public class RequestBodyExtension : RequestBody, IRequestBodyExtension
    {
        public const string autoFunctionCall = "auto";
        public const string noneFunctionCall = "none";

        public int? MaxTokens { get; set; }

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
                    FunctionCallString = (string)(value ?? string.Empty);
                }
                else
                {
                    FunctionCallObject = (IFunctionCallRequest?)value;
                }
            }
        }
    }
}
