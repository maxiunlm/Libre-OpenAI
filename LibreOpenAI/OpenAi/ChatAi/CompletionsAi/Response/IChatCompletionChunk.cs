using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices;
using Newtonsoft.Json;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response
{
    public interface IChatCompletionChunk
    {
        /// <summary>
        /// A list of chat completion choices. Can contain more than one elements if n is greater than 1. Can also be empty for the last chunk if you set stream_options: {"include_usage": true}.
        /// </summary>
        [JsonProperty("choices")]
        List<ChoiceChunk> Choices { get; set; }
        /// <summary>
        /// The Unix timestamp (in seconds) of when the chat completion was created. Each chunk has the same timestamp.
        /// </summary>
        [JsonProperty("created")]
        long Created { get; set; }
        /// <summary>
        /// A unique identifier for the chat completion. Each chunk has the same ID.
        /// </summary>
        [JsonProperty("id")]
        string Id { get; set; }
        /// <summary>
        /// The model to generate the completion.
        /// </summary>
        [JsonProperty("model")]
        string Model { get; set; }
        /// <summary>
        /// The object type, which is always chat.completion.chunk.
        /// </summary>
        [JsonProperty("object")]
        string Object { get; set; }
        /// <summary>
        /// This fingerprint represents the backend configuration that the model runs with. Can be used in conjunction with the seed request parameter to understand when backend changes have been made that might impact determinism.
        /// </summary>
        [JsonProperty("system_fingerprint")]
        string SystemFingerprint { get; set; }

        // TODO : https://platform.openai.com/docs/api-reference/chat/streaming 
        // usage
        //object or null
        //An optional field that will only be present when you set stream_options: {"include_usage": true} in your request.When present, it contains a null value except for the last chunk which contains the token usage statistics for the entire request.
        //    Hide properties
        //completion_tokens
        //    integer
        //Number of tokens in the generated completion.
        //    prompt_tokens
        //    integer
        //Number of tokens in the prompt.
        //total_tokens
        //    integer
        //Total number of tokens used in the request (prompt + completion).

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("usage")]
        object? Usage { get; set; } // TODO: create Usage Objects if it is necessary

        /// <summary>
        /// The service tier used for processing the request. This field is only included if the service_tier parameter is specified in the request.
        /// </summary>
        [JsonProperty("service_tier")]
        string? ServiceTier { get; set; }
    }
}