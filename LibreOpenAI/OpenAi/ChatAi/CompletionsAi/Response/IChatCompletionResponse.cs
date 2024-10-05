using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Usage;
using Newtonsoft.Json;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response
{
    public interface IChatCompletionResponse
    {
        /// <summary>
        /// A unique identifier for the chat completion.
        /// </summary>
        [JsonProperty("id")]
        string Id { get; set; }
        /// <summary>
        /// The object type, which is always chat.completion
        /// </summary>
        [JsonProperty("object")]
        string Object { get; set; }
        /// <summary>
        /// The Unix timestamp (in seconds) of when the chat completion was created.
        /// </summary>
        [JsonProperty("created")]
        long Created { get; set; }
        /// <summary>
        /// The model used for the chat completion.
        /// </summary>
        [JsonProperty("model")]
        string Model { get; set; }
        /// <summary>
        /// The service tier used for processing the request. This field is only included if the service_tier parameter is specified in the request.
        /// </summary>
        [JsonProperty("service_tier")]
        string? ServiceTier { get; set; }
        /// <summary>
        /// This fingerprint represents the backend configuration that the model runs with.
        /// Can be used in conjunction with the seed request parameter to understand when backend changes have been made that might impact determinism.
        /// </summary>
        [JsonProperty("system_fingerprint")]
        string? SystemFingerprint { get; set; }
        /// <summary>
        /// A list of chat completion choices. Can be more than one if n is greater than 1.
        /// </summary>
        [JsonProperty("choices")]
        // TODO: this [JsonConverter(typeof(ChoiceResponseConverter))] or AutoMapper
        List<ChoiceResponse> Choices { get; set; }
        /// <summary>
        /// Usage statistics for the completion request.
        /// </summary>
        [JsonProperty("usage")]
        UsageResponse Usage { get; set; }
    }
}