using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages.ToolCalls.Function;
using Newtonsoft.Json;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages.ToolCalls
{
    public interface IToolCallRequest
    {
        /// <summary>
        /// The function that the model called. (Required)
        /// </summary>
        [JsonProperty("function")]
        IFunctionRequest Function { get; set; }
        /// <summary>
        /// The ID of the tool call. (Required)
        /// </summary>
        [JsonProperty("id")]
        string Id { get; set; }
        /// <summary>
        /// The type of the tool. Currently, only function is supported. (Required)
        /// </summary>
        [JsonProperty("type")]
        string Type { get; set; }
    }
}