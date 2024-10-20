using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.ResponseFormat;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.StreamOptions;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Tools;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Tools.Choise;
using Newtonsoft.Json;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests
{
    public interface IRequestBody
    {
        /// <summary>
        /// An upper bound for the number of tokens that can be generated for a completion, including visible output tokens and reasoning tokens.
        /// </summary>
        /// <see cref="https://platform.openai.com/docs/guides/reasoning"/>
        [JsonProperty("max_completion_tokens")]
        int? MaxCompletionTokens { get; set; }
        /// <summary>
        /// ID of the model to use. See the model endpoint compatibility table for details on which models work with the Chat API. (Required)
        /// </summary>
        /// <see cref="https://platform.openai.com/docs/models/model-endpoint-compatibility"/>
        [JsonProperty("model")]
        string Model { get; set; }
        /// <summary>
        /// Number between -2.0 and 2.0. Positive values penalize new tokens based on their existing frequency in the text so far, decreasing the model's likelihood to repeat the same line verbatim.
        /// </summary>
        /// <see cref="https://platform.openai.com/docs/guides/text-generation/parameter-details"/>
        [JsonProperty("frequency_penalty")]
        decimal? FrequencyPenalty { get; set; }
        /// <summary>
        /// Number between -2.0 and 2.0. Positive values penalize new tokens based on whether they appear in the text so far, increasing the model's likelihood to talk about new topics.
        /// See more information about frequency and presence penalties.
        /// </summary>
        /// <see cref="https://platform.openai.com/docs/guides/text-generation/parameter-details"/>
        [JsonProperty("presence_penalty")]
        decimal? PresencePenalty { get; set; }
        /// <summary>
        /// Whether to return log probabilities of the output tokens or not. If true, returns the log probabilities of each output token returned in the content of message.
        /// </summary>
        [JsonProperty("logprobs")]
        bool? Logprobs { get; set; }
        /// <summary>
        /// An integer between 0 and 20 specifying the number of most likely tokens to return at each token position, each with an associated log probability. logprobs must be set to true if this parameter is used.
        /// </summary>
        /// <remarks>See Logprobs</remarks>
        [JsonProperty("top_logprobs")]
        int? TopLogprobs { get; set; }
        /// <summary>
        /// How many chat completion choices to generate for each input message. Note that you will be charged based on the number of generated tokens across all of the choices. Keep n as 1 to minimize costs.
        /// </summary>
        /// <remarks>Libre OpneAI uses N = 1 by default.</remarks>
        [JsonProperty("n")]
        int? N { get; set; }
        /// <summary>
        /// If specified, our system will make a best effort to sample deterministically, such that repeated requests with the same seed and parameters should return the same result.
        /// </summary>
        /// <remarks>This feature is in Beta - Determinism is not guaranteed, and you should refer to the system_fingerprint response parameter to monitor changes in the backend.</remarks>
        [JsonProperty("seed")]
        int? Seed { get; set; }
        /// <summary>
        /// Specifies the latency tier to use for processing the request. This parameter is relevant for customers subscribed to the scale tier service:
        ///     * If set to 'auto', and the Project is Scale tier enabled, the system will utilize scale tier credits until they are exhausted.
        ///     * If set to 'auto', and the Project is not Scale tier enabled, the request will be processed using the default service tier with a lower uptime SLA and no latency guarentee.
        ///     * If set to 'default', the request will be processed using the default service tier with a lower uptime SLA and no latency guarentee.
        ///     * When not set, the default behavior is 'auto'.
        /// When this parameter is set, the response body will include the service_tier utilized.
        /// </summary>
        [JsonProperty("service_tier")]
        string ServiceTier { get; set; }
        /// <summary>
        /// Up to 4 sequences where the API will stop generating further tokens.
        /// </summary>
        /// <remarks>string/array/null; Optional; Defaults to null</remarks>
        [JsonProperty("stop")]
        List<string>? Stop { get; set; }
        /// <summary>
        /// If set, partial message deltas will be sent, like in ChatGPT. Tokens will be sent as data-only server-sent events as they become available, with the stream terminated by a data: [DONE] message.
        /// </summary>
        /// <see cref="https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events/Using_server-sent_events#Event_stream_format"/>
        /// <seealso cref="https://cookbook.openai.com/examples/how_to_stream_completions"/>
        [JsonProperty("stream")]
        bool? Stream { get; set; }
        /// <summary>
        /// A list of messages comprising the conversation so far. (Required)
        /// </summary>
        [JsonProperty("messages")]
        List<IMessageRequest> Messages { get; set; }
        /// <summary>
        /// Modify the likelihood of specified tokens appearing in the completion.
        /// Accepts a JSON object that maps tokens(specified by their token ID in the tokenizer) to an associated bias value from -100 to 100. Mathematically, the bias is added to the logits generated by the model prior to sampling.The exact effect will vary per model, but values between -1 and 1 should decrease or increase likelihood of selection; values like -100 or 100 should result in a ban or exclusive selection of the relevant token.
        /// </summary>
        [JsonProperty("logit_bias")]
        Dictionary<string, int> LogitBias { get; set; }
        /// <summary>
        /// An object specifying the format that the model must output. Compatible with GPT-4o, GPT-4o mini, GPT-4 Turbo and all GPT-3.5 Turbo models newer than gpt-3.5-turbo-1106.
        /// Setting to { "type": "json_schema", "json_schema": { ...} } enables Structured Outputs which ensures the model will match your supplied JSON schema.Learn more in the Structured Outputs guide.
        /// Setting to { "type": "json_object" } enables JSON mode, which ensures the message the model generates is valid JSON.
        /// </summary>
        /// <remarks>
        /// Important: when using JSON mode, you must also instruct the model to produce JSON yourself via a system or user message.Without this, the model may generate an unending stream of whitespace until the generation reaches the token limit, resulting in a long-running and seemingly "stuck" request.Also note that the message content may be partially cut off if finish_reason= "length", which indicates the generation exceeded max_tokens or the conversation exceeded the max context length.
        /// </remarks>
        /// <see cref="https://platform.openai.com/docs/models/gpt-4o"/>
        /// <seealso cref="https://platform.openai.com/docs/models/gpt-4o-mini"/>
        /// <seealso cref="https://platform.openai.com/docs/models/gpt-4-and-gpt-4-turbo"/>
        /// <seealso cref="https://platform.openai.com/docs/guides/structured-outputs"/>
        [JsonProperty("response_format")]
        IResponseFormatRequest? ResponseFormat { get; set; }
        [JsonIgnore]
        bool MustThrowStreamOptionsException { get; set; }
        /// <summary>
        /// Options for streaming response.
        /// </summary>
        /// <remarks>Only set this when you set stream: true.</remarks>
        [JsonProperty("stream_options")]
        IStreamOptionsRequest? StreamOptions { get; set; }
        [JsonIgnore]
        bool MustThrowTemperatureOrTopPException { get; set; }
        /// <summary>
        /// What sampling temperature to use, between 0 and 2. Higher values like 0.8 will make the output more random, while lower values like 0.2 will make it more focused and deterministic.
        /// </summary>
        /// <remarks>We generally recommend altering this or top_p but not both. Defaults to 1</remarks>
        [JsonProperty("temperature")]
        decimal? Temperature { get; set; }
        /// <summary>
        /// An alternative to sampling with temperature, called nucleus sampling, where the model considers the results of the tokens with top_p probability mass. So 0.1 means only the tokens comprising the top 10% probability mass are considered.
        /// </summary>
        /// <remarks> We generally recommend altering this or temperature but not both. Defaults to 1</remarks>
        [JsonProperty("top_p")]
        decimal? TopP { get; set; }
        /// <summary>
        /// A list of tools the model may call. Currently, only functions are supported as a tool. Use this to provide a list of functions the model may generate JSON inputs for.
        /// </summary>
        /// <remarks>A max of 128 functions are supported.</remarks>
        [JsonProperty("tools")]
        List<IToolRequest> Tools { get; set; }
        /// <summary>
        /// Controls which (if any) tool is called by the model. 'none' means the model will not call any tool and instead generates a message. 'auto' means the model can pick between generating a message or calling one or more tools. required means the model must call one or more tools. Specifying a particular tool via {"type": "function", "function": {"name": "my_function"}} forces the model to call that tool.
        ///     * String: 'none' means the model will not call any tool and instead generates a message. 'auto' means the model can pick between generating a message or calling one or more tools. "required" means the model must call one or more tools.
        ///     * Object: Specifies a tool the model should use. Use to force the model to call a specific function.
        /// </summary>
        /// <remarks>'none' is the default when no tools are present. 'auto' is the default if tools are present.</remarks>
        [JsonProperty("tool_choice")]
        object? ToolChoice { get; set; }
        [JsonIgnore]
        string? ToolChoiceString { get; set; }
        [JsonIgnore]
        IToolChoiseRequest? ToolChoiceObject { get; set; }
        /// <summary>
        /// Whether to enable parallel function calling during tool use.
        /// </summary>
        /// <remarks>https://platform.openai.com/docs/guides/function-calling/parallel-function-calling</remarks>
        [JsonProperty("parallel_tool_calls")]
        bool ParallelToolCalls { get; set; }
        /// <summary>
        /// A unique identifier representing your end-user, which can help OpenAI to monitor and detect abuse.
        /// </summary>
        /// <see cref="https://platform.openai.com/docs/guides/safety-best-practices/end-user-ids"/>
        [JsonProperty("user")]
        string User { get; set; }
    }
}