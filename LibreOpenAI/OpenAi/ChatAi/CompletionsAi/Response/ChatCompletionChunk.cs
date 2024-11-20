﻿using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response
{
    public class ChatCompletionChunk : IChatCompletionChunk
    {
        public string Id { get; set; }
        public string Object { get; set; }
        public long Created { get; set; }
        public string Model { get; set; }
        public string SystemFingerprint { get; set; }
        public List<ChoiceChunk> Choices { get; set; }
        public object? Usage { get; set; }
        public string? ServiceTier { get; set; }
    }
}
