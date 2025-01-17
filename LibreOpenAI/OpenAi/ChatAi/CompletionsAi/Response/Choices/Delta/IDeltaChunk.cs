﻿using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Delta.ToolCalls;
using Newtonsoft.Json;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Delta
{
    public interface IDeltaChunk
    {
        /// <summary>
        /// The contents of the chunk message.
        /// </summary>
        [JsonProperty("content")]
        string? Content { get; set; }
        /// <summary>
        /// The refusal message generated by the model.
        /// </summary>
        [JsonProperty("refusal")]
        string? Refusal { get; set; }
        /// <summary>
        /// The role of the author of this message.
        /// </summary>
        [JsonProperty("role")]
        string Role { get; set; }
        /// <summary>
        /// The tool calls generated by the model.
        /// </summary>
        [JsonProperty("tool_calls")]
        List<ToolCallsChunk> ToolCalls { get; set; }
    }
}