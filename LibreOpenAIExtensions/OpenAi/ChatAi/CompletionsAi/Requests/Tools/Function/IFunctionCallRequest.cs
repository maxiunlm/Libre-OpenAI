using Newtonsoft.Json;

namespace LibreOpenAIExtensions.OpenAi.ChatAi.CompletionsAi.Requests.Tools.Function
{
    public interface IFunctionCallRequest
    {
        /// <summary>
        /// The name of the function to call. (Required)
        /// </summary>
        /// <remarks>Specifying a particular function via {"name": "my_function"} forces the model to call that function.</remarks>
        [JsonProperty("name")]
        string Name { get; set; }
    }
}
