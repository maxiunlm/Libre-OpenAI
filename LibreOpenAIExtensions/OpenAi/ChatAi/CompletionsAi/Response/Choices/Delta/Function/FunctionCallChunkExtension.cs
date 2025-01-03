﻿using Newtonsoft.Json;

namespace LibreOpenAIExtensions.OpenAi.ChatAi.CompletionsAi.Response.Choices.Delta.Function
{
    public class FunctionCallChunkExtension
    {
        /// <summary>
        /// The arguments to call the function with, as generated by the model in JSON format.Note that the model does not always generate valid JSON, and may hallucinate parameters not defined by your function schema. Validate the arguments in your code before calling your function.
        /// </summary>
        [JsonProperty("arguments")]
        public string Arguments { get; set; }
        /// <summary>
        /// The name of the function to call.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
