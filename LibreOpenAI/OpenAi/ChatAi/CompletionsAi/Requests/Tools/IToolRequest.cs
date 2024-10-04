using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Tools.Function;
using Newtonsoft.Json;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Tools
{
    public interface IToolRequest
    {
        /// <summary>
        /// The type of the tool. (Required)
        /// </summary>
        /// <remarks>Currently, only function is supported.</remarks>
        [JsonProperty("type")]
        string Type { get; set; }
        /// <summary>
        /// (Required)
        /// </summary>
        [JsonProperty("function")]
        IFunctionToolRequest Function { get; set; }
    }
}