using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Delta.ToolCalls.Function;
using Newtonsoft.Json;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Delta.ToolCalls
{
    public interface IToolCallsChunk
    {
        /// <summary>
        /// The index.
        /// </summary>
        [JsonProperty("index")]
        int Index { get; set; }
        /// <summary>
        /// The function that the model called.
        /// </summary>
        [JsonProperty("function")]
        ToolCallsFunctionChunk Function { get; set; }
        /// <summary>
        /// The ID of the tool call.
        /// </summary>
        [JsonProperty("id")]
        string Id { get; set; }
        /// <summary>
        /// The type of the tool. Currently, only function is supported.
        /// </summary>
        [JsonProperty("type")]
        string Type { get; set; }
    }
}