using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.ResponseFormat;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.StreamOptions;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Tools;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Tools.Choise;
using Newtonsoft.Json;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests
{
    public class RequestBody : IRequestBody
    {
        private const int nMinimunCost = 1;
        private const string defaultServiceTier = "default";
        private const string defaultToolChoiseWithTools = "auto";
        private const string defaultToolChoiseWithoutTools = "none";

        public int? MaxCompletionTokens { get; set; }
        public required string Model { get; set; }
        public required List<IMessageRequest> Messages { get; set; }

        [JsonProperty("logit_bias")]
        public Dictionary<string, int> LogitBias { get; set; } = new Dictionary<string, int>();

        private decimal? frequency_penalty;
        public decimal? FrequencyPenalty
        {
            get => frequency_penalty;
            set
            {
                if (value != null && (value < -2.0m || value > 2.0m))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Frequency_Penalty must be between -2.0 and 2.0.");
                }

                frequency_penalty = value;
            }
        }

        private decimal? presence_penalty;
        public decimal? PresencePenalty
        {
            get => presence_penalty;
            set
            {
                if (value != null && (value < -2.0m || value > 2.0m))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Presence_penalty must be between -2.0 and 2.0.");
                }

                presence_penalty = value;
            }
        }
        // TODO: WARNING: We generally recommend altering this or temperature but not both. Defaults to 1
        public decimal? TopP { get; set; }
        // TODO: WARNING: We generally recommend altering this or top_p but not both. Defaults to 1

        private decimal? temperature;
        public decimal? Temperature
        {
            get => temperature;
            set
            {
                if (value != null && (value < -2.0m || value > 2.0m))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Temperature must be between 0.0 and 2.0.");
                }

                temperature = value;
            }
        }
        public bool? Logprobs { get; set; }
        public int? TopLogprobs { get; set; }
        public int? N { get; set; } = nMinimunCost;
        public int? Seed { get; set; }
        public string ServiceTier { get; set; } = defaultServiceTier;
        public List<string> Stop { get; set; } = new List<string>();
        public bool? Stream { get; set; }
        // TODO: Review Important: when using JSON mode, you must also instruct the model to produce JSON yourself via a system or user message.
        // Without this, the model may generate an unending stream of whitespace until the generation reaches the token limit, resulting in a long-running and seemingly "stuck" request.Also note that the message content may be partially cut off if finish_reason= "length", which indicates the generation exceeded max_tokens or the conversation exceeded the max context length.
        public IResponseFormatRequest? ResponseFormat { get; set; }
        // TODO: Only set this when you set stream: true.
        public IStreamOptionsRequest? StreamOptions { get; set; }
        public List<IToolRequest> Tools { get; set; } = new List<IToolRequest>();
        private string? tool_choiceString;
        private IToolChoiseRequest? tool_choiceObject;
        public object? ToolChoice
        {
            get
            {
                if (Tools != null && Tools.Any())
                {
                    tool_choiceString ??= defaultToolChoiseWithTools;
                }
                else
                {
                    tool_choiceString ??= defaultToolChoiseWithoutTools;
                }

                return tool_choiceString;
            }
            set
            {
                if (value is string)
                {
                    tool_choiceString = (string)(value ?? string.Empty);
                }
                else
                {
                    tool_choiceObject = (IToolChoiseRequest?)value;
                }
            }
        }
        public bool ParallelToolCalls { get; set; } = true;
        public string User { get; set; } = string.Empty;
    }
}
