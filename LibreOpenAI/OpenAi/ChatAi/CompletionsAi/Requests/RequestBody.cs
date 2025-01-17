﻿using LibreOpenAI.Exceptions;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.ResponseFormat;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.StreamOptions;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Tools;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Tools.Choise;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests
{
    public class RequestBody : IRequestBody
    {
        public const decimal defaultTopP = 1m;
        public const decimal defaultTemperature = 1m;
        private const int nMinimunCost = 1;
        private const string defaultServiceTier = "default";
        private const string defaultToolChoiseWithTools = "auto";
        private const string defaultToolChoiseWithoutTools = "none";

        public int? MaxCompletionTokens { get; set; }
        public required string Model { get; set; }
        public virtual required List<MessageRequest> Messages { get; set; }

        public Dictionary<string, int>? LogitBias { get; set; } // HACK: = new Dictionary<string, int>();

        private decimal? frequencyPenalty;
        public decimal? FrequencyPenalty
        {
            get => frequencyPenalty;
            set
            {
                if (value != null && (value < -2.0m || value > 2.0m))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Frequency_Penalty must be between -2.0 and 2.0.");
                }

                frequencyPenalty = value;
            }
        }

        private decimal? presencePenalty;
        public decimal? PresencePenalty
        {
            get => presencePenalty;
            set
            {
                if (value != null && (value < -2.0m || value > 2.0m))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Presence_penalty must be between -2.0 and 2.0.");
                }

                presencePenalty = value;
            }
        }
        public bool MustThrowTemperatureOrTopPException { get; set; }
        // NOTE: WARNING: We generally recommend altering this or temperature but not both. Defaults to 1
        private decimal? topP { get; set; }
        public decimal? TopP
        {
            get => topP;
            set
            {
                topP = value;

                if (topP != null && temperature != null)
                {
                    if (MustThrowTemperatureOrTopPException)
                    {
                        throw new LibreOpenAiTemperatureXorTopPException();
                    }
                    else
                    {
                        temperature = null;
                    }
                }
            }
        }
        // NOTE: WARNING: We generally recommend altering this or top_p but not both. Defaults to 1
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

                if (topP != null && temperature != null)
                {
                    if (MustThrowTemperatureOrTopPException)
                    {
                        throw new LibreOpenAiTemperatureXorTopPException();
                    }
                    else
                    {
                        topP = null;
                    }
                }
            }
        }
        public bool? Logprobs { get; set; }
        public int? TopLogprobs { get; set; }
        public int? N { get; set; } = nMinimunCost;
        public int? Seed { get; set; }
        public string? ServiceTier { get; set; } // HACK: = defaultServiceTier;
        public List<string>? Stop { get; set; } // HACK: = new List<string>();
        public bool? Stream { get; set; }
        // NOTE: WARNING: Review Important: when using JSON mode, you must also instruct the model to produce JSON yourself via a system or user message.
        // Without this, the model may generate an unending stream of whitespace until the generation reaches the token limit,
        // resulting in a long-running and seemingly "stuck" request.
        // Also note that the message content may be partially cut off if finish_reason= "length",
        // which indicates the generation exceeded max_tokens or the conversation exceeded the max context length.
        // That's the reason why we are not allowing to use "response_format": "json".
        private IResponseFormatRequest? responseFormat { get; set; }
        public IResponseFormatRequest? ResponseFormat { get; set; }
        public bool MustThrowStreamOptionsException { get; set; }
        // NOTE: Only set this when you set stream: true.
        private IStreamOptionsRequest? streamOptions;
        public IStreamOptionsRequest? StreamOptions
        {
            get
            {
                return streamOptions;
            }
            set
            {
                if (value != null && (Stream == null || !Stream.Value))
                {
                    if (MustThrowStreamOptionsException)
                    {
                        throw new LibreOpenAiStreamOptionsException();
                    }
                    else
                    {
                        streamOptions = null;
                        return;
                    }
                }

                streamOptions = value;
            }
        }
        public List<ToolRequest>? Tools { get; set; } // HACK: = new List<ToolRequest>();
        private string? toolChoiceString;
        public string? ToolChoiceString
        {
            get => toolChoiceString;
            set
            {
                toolChoiceObject = null;
                toolChoiceString = value;
            }
        }
        private IToolChoiseRequest? toolChoiceObject;
        public IToolChoiseRequest? ToolChoiceObject
        {
            get => toolChoiceObject;
            set
            {
                toolChoiceString = null;
                toolChoiceObject = value;
            }
        }
        public object? ToolChoice
        {
            get
            {
                if (ToolChoiceObject != null)
                {
                    return ToolChoiceObject;
                }
                else if (Tools != null && Tools.Any())
                {
                    ToolChoiceString ??= defaultToolChoiseWithTools;
                }
                // HACK:
                //else
                //{
                //    ToolChoiceString ??= defaultToolChoiseWithoutTools;
                //}

                return ToolChoiceString;
            }
            set
            {
                if (value is string)
                {
                    ToolChoiceString = (string)(value ?? string.Empty);
                }
                else
                {
                    ToolChoiceObject = (IToolChoiseRequest?)value;
                }
            }
        }
        public bool? ParallelToolCalls { get; set; } // HACK: = true;
        public string? User { get; set; } // HACK: = string.Empty;
    }
}
