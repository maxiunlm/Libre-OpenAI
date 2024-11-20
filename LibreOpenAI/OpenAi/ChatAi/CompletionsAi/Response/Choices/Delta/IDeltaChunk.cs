﻿using Newtonsoft.Json;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Delta
{
    public interface IDeltaChunk
    {
        /// <summary>
        /// The contents of the chunk message.
        /// </summary>
        [JsonProperty("")]
        string Content { get; set; }
        /// <summary>
        /// The refusal message generated by the model.
        /// </summary>
        [JsonProperty("")]
        object Refusal { get; set; }
        /// <summary>
        /// The role of the author of this message.
        /// </summary>
        [JsonProperty("")]
        string Role { get; set; }

        // TODO: tool_calls, 
        //TODO: Deprecated -> function_call
    }
}