﻿using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Delta;
using LibreOpenAIExtensions.OpenAi.ChatAi.CompletionsAi.Response.Choices.Delta.Function;
using Newtonsoft.Json;

namespace LibreOpenAIExtensions.OpenAi.ChatAi.CompletionsAi.Response.Choices.Delta
{
    public class DeltaChunkExtension: DeltaChunk
    {
        /// <summary>
        /// Deprecated and replaced by tool_calls.The name and arguments of a function that should be called, as generated by the model.
        /// </summary>
        [JsonProperty("function_call")]
        public FunctionCallChunkExtension FunctionCall { get; set; }
    }
}
