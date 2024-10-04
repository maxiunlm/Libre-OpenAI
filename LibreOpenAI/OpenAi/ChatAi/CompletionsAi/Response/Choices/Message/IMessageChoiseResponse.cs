﻿using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Message.ToolCalls;
using Newtonsoft.Json;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Message
{
    public interface IMessageChoiseResponse
    {
        /// <summary>
        /// The contents of the message.
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
        /// The tool calls generated by the model, such as function calls.
        /// </summary>
        [JsonProperty("tool_calls")]
        List<IToolCallsResponse> ToolCalls { get; set; }
    }
}