﻿using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages.Conents;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages.ToolCalls;
using Newtonsoft.Json;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests.Messages
{
    public interface IMessageRequest
    {
        [JsonIgnore]
        bool MustThrowRequiredContentException { get; set; }
        [JsonIgnore]
        bool MustThrowRequiredToolCallIdException { get; set; }
        [JsonIgnore]
        bool MustVerifyWrongContentForRoleException { get; set; }
        [JsonIgnore]
        bool MustThrowWrongContentForRoleException { get; set; }
        [JsonIgnore]
        string? OneContent { get; set; }
        [JsonIgnore]
        List<string>? ContentList { get; set; }
        [JsonIgnore]
        List<IAudioContentPart>? ContentInputAudioList { get; set; }
        [JsonIgnore]
        List<IImageContentPart>? ContentImageUrlList { get; set; }
        [JsonIgnore]
        List<ITextContentPart>? ContentTextList { get; set; }
        [JsonIgnore]
        List<IRefusalContentPart>? ContentRefusalList { get; set; }
        /// <summary>
        /// 1 The contents of the system message. (Required)
        /// 2 The contents of the user message. (Required)
        /// 3 The contents of the assistant message. Required unless tool_calls or function_call (deprecated) is specified.
        /// 4 The contents of the tool message. (Required)
        /// </summary>
        [JsonProperty("content")]
        object? Content { get; set; }
        /// <summary>
        /// 1 The role of the messages author, in this case system. (Required)
        /// 2 The role of the messages author, in this case user. (Required)
        /// 3 The role of the messages author, in this case assistant. (Required)
        /// 4 The role of the messages author, in this case tool. (Required)
        /// </summary>
        [JsonProperty("role")]
        string Role { get; set; }
        /// <summary>
        /// 1-3 An optional name for the participant. Provides the model information to differentiate between participants of the same role.
        /// </summary>
        [JsonProperty("name")]
        string? Name { get; set; }
        /// <summary>
        /// 3 The refusal message by the assistant.
        /// </summary>
        [JsonProperty("refusal")]
        string? Refusal { get; set; }
        /// <summary>
        /// 4 Tool call that this message is responding to. (Required)
        /// </summary>
        [JsonProperty("tool_call_id")]
        string? ToolCallId { get; set; }
        /// <summary>
        /// 3 The tool calls generated by the model, such as function calls.
        /// </summary>
        [JsonProperty("tool_calls")]
        List<IToolCallRequest>? ToolCalls { get; set; }
    }
}