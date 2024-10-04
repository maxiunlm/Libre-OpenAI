using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Tools.Choise.Function;
using Newtonsoft.Json;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Tools.Choise
{
    public interface IToolChoiseRequest
    {
        /// <summary>
        /// The type of the tool. Currently, only function is supported. (Required)
        /// </summary>
        [JsonProperty("type")]
        string Type { get; set; }
        /// <summary>
        /// (Required)
        /// </summary>
        [JsonProperty("function")]
        IFunctionToolChoiseRequest Function { get; set; }
    }
}