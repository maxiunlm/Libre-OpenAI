using Newtonsoft.Json;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Tools.Choise.Function
{
    public interface IFunctionToolChoiseRequest
    {
        /// <summary>
        /// The name of the function to call. (Required)
        /// </summary>
        [JsonProperty("name")]
        string Name { get; set; }
    }
}