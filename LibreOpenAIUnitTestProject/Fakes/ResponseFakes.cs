namespace LibreOpenAIUnitTestProject.Fakes
{
    internal static class ResponseFakes
    {
        public const string whatIsTheCapitalOfFrance = "What is the capital of France?";
        public const string theCapitalOfFranceIsParis = "The capital of France is Paris";
        public const string theCapitalOfFranceIsParisJson = @"{
    ""id"": ""chatcmpl-12345"",
    ""object"": ""chat.completion"",
    ""created"": 1694800000,
    ""model"": ""gpt-3.5-turbo"",
    ""choices"": [
        {
            ""index"": 0,
            ""message"": {
                ""role"": ""assistant"",
                ""content"": """ + theCapitalOfFranceIsParis + @"""
            },
            ""finish_reason"": ""stop""
        }
    ],
    ""usage"": {
        ""prompt_tokens"": 10,
        ""completion_tokens"": 8,
        ""total_tokens"": 18
    }
}";
        public const string youAreAHelpfulAssistant = "You are a helpful assistant.";
        public const string helloThereHowMayIAssistYouToday = "\n\nHello there, how may I assist you today?";
        public const string youAreAHelpfulAssistantJson = @"{
  ""id"": ""chatcmpl-123"",
  ""object"": ""chat.completion"",
  ""created"": 1677652288,
  ""model"": ""gpt-4o-mini"",
  ""system_fingerprint"": ""fp_44709d6fcb"",
  ""choices"": [{
    ""index"": 0,
    ""message"": {
      ""role"": ""assistant"",
      ""content"": """ + helloThereHowMayIAssistYouToday + @""",
    },
    ""logprobs"": null,
    ""finish_reason"": ""stop""
  }],
  ""usage"": {
    ""prompt_tokens"": 9,
    ""completion_tokens"": 12,
    ""total_tokens"": 21,
    ""completion_tokens_details"": {
        ""reasoning_tokens"": 0
        }
    }
}
";
        public const string testForMultipleChoices = "Can you give me two different responses to the question?";
        public const string testForMultipleChoicesResponseFirst = "This is the first response.";
        public const string testForMultipleChoicesResponseSecond = "This is the second response.";
        public const string multiChoiceResponseJson = @"{
  ""id"": ""chatcmpl-456"",
  ""object"": ""chat.completion"",
  ""created"": 1677652290,
  ""model"": ""gpt-4o-max"",
  ""choices"": [
    {
      ""index"": 0,
      ""message"": { ""role"": ""assistant"", ""content"": ""This is the first response.""},
      ""logprobs"": null,
      ""finish_reason"": ""stop""
    },
    {
      ""index"": 1,
      ""message"": { ""role"": ""assistant"", ""content"": ""This is the second response.""},
      ""logprobs"": null,
      ""finish_reason"": ""stop""
    }
  ],
  ""usage"": {
    ""prompt_tokens"": 15,
    ""completion_tokens"": 10,
    ""total_tokens"": 25
  }
}";
        public const string testForDifferentFinishReasonValues = "Test for different finish reason values";
        public const string truncatedResponseJson = @"{
  ""id"": ""chatcmpl-789"",
  ""object"": ""chat.completion"",
  ""created"": 1677652295,
  ""model"": ""gpt-4o-long"",
  ""choices"": [{
    ""index"": 0,
    ""message"": { ""role"": ""assistant"", ""content"": ""This response was cut short...""},
    ""logprobs"": null,
    ""finish_reason"": ""length""
  }],
  ""usage"": {
    ""prompt_tokens"": 20,
    ""completion_tokens"": 5,
    ""total_tokens"": 25
  }
}";
        public const string testForLogprobsPresent = "Test logprobs presence";
        public const string logprobsResponseJson = @"{
  ""id"": ""chatcmpl-101"",
  ""object"": ""chat.completion"",
  ""created"": 1677652299,
  ""model"": ""gpt-4o-log"",
  ""choices"": [{
    ""index"": 0,
    ""message"": { ""role"": ""assistant"", ""content"": ""Here's a response with logprobs.""},
    ""logprobs"": {
      ""tokens"": [""Here's"", ""a"", ""response"", ""with"", ""logprobs.""],
      ""token_logprobs"": [-0.5, -0.3, -0.6, -0.2, -0.1],
      ""top_logprobs"": [
        {""Here's"": -0.5},
        {""a"": -0.3},
        {""response"": -0.6},
        {""with"": -0.2},
        {""logprobs."": -0.1}
      ]
    },
    ""finish_reason"": ""stop""
  }],
  ""usage"": {
    ""prompt_tokens"": 20,
    ""completion_tokens"": 8,
    ""total_tokens"": 28
  }
}";
        public const string testHighTokenUsageResponse = "Test for different usage scenarios";
        public const string highTokenUsageResponseJson = @"{
  ""id"": ""chatcmpl-303"",
  ""object"": ""chat.completion"",
  ""created"": 1677652300,
  ""model"": ""gpt-4o-heavy"",
  ""choices"": [{
    ""index"": 0,
    ""message"": { ""role"": ""assistant"", ""content"": ""Here's a long response to test high token usage.""},
    ""logprobs"": null,
    ""finish_reason"": ""stop""
  }],
  ""usage"": {
    ""prompt_tokens"": 1000,
    ""completion_tokens"": 800,
    ""total_tokens"": 1800
  }
}";
        public const string testEmptyChoicesResponse = "Test edge cases for choices";
        public const string emptyChoicesResponseJson = @"{
  ""id"": ""chatcmpl-404"",
  ""object"": ""chat.completion"",
  ""created"": 1677652305,
  ""model"": ""gpt-4o-silent"",
  ""choices"": [],
  ""usage"": {
    ""prompt_tokens"": 10,
    ""completion_tokens"": 0,
    ""total_tokens"": 10
  }
}";
        public const string testAStandardCompletionResponseFromChatGpt = "Test a standard completion response from ChatGPT";
        public const string aStandardCompletionResponseFromChatGptJson = @"{
  ""id"": ""chatcmpl-123"",
  ""object"": ""chat.completion"",
  ""created"": 1677652288,
  ""model"": ""gpt-4"",
  ""choices"": [
    {
      ""index"": 0,
      ""message"": {
        ""role"": ""assistant"",
        ""content"": ""Hello!""
      },
      ""logprobs"": null,
      ""finish_reason"": ""stop""
    }
  ],
  ""usage"": {
    ""prompt_tokens"": 10,
    ""completion_tokens"": 5,
    ""total_tokens"": 15
  }
}";
        public const string testLogprobsResponseWithTextOffset = "Test logprobs response with text offset";
        public const string logprobsResponseWithTextOffsetJson = @"{
  ""id"": ""chatcmpl-101"",
  ""object"": ""chat.completion"",
  ""created"": 1677652299,
  ""model"": ""gpt-4o-log"",
  ""choices"": [{
    ""index"": 0,
    ""message"": { ""role"": ""assistant"", ""content"": ""Here's a response with logprobs and text offsets.""},
    ""logprobs"": {
      ""tokens"": [""Here's"", ""a"", ""response"", ""with"", ""logprobs.""],
      ""token_logprobs"": [-0.5, -0.3, -0.6, -0.2, -0.1],
      ""top_logprobs"": [
        {""Here's"": -0.5},
        {""a"": -0.3},
        {""response"": -0.6},
        {""with"": -0.2},
        {""logprobs."": -0.1}
      ],
      ""text_offset"": [0, 6, 8, 17, 22]
    },
    ""finish_reason"": ""stop""
  }],
  ""usage"": {
    ""prompt_tokens"": 20,
    ""completion_tokens"": 8,
    ""total_tokens"": 28
  }
}";
        public const string testFunctionCallFinishReason = "Test function call finish reason";
        public const string functionCallFinishReasonJson = @"{
  ""id"": ""chatcmpl-789"",
  ""object"": ""chat.completion"",
  ""created"": 1677652295,
  ""model"": ""gpt-4o-long"",
  ""choices"": [{
    ""index"": 0,
    ""message"": { ""role"": ""assistant"", ""content"": ""This response triggered a function call.""},
    ""logprobs"": null,
    ""finish_reason"": ""function_call""
  }],
  ""usage"": {
    ""prompt_tokens"": 20,
    ""completion_tokens"": 5,
    ""total_tokens"": 25
  }
}";
        public const string testDetailedTokenUsageResponse = "";
        public const string detailedTokenUsageResponseJson = @"{
  ""id"": ""chatcmpl-303"",
  ""object"": ""chat.completion"",
  ""created"": 1677652300,
  ""model"": ""gpt-4o-heavy"",
  ""choices"": [{
    ""index"": 0,
    ""message"": { ""role"": ""assistant"", ""content"": ""This response includes detailed token usage.""},
    ""logprobs"": null,
    ""finish_reason"": ""stop""
  }],
  ""usage"": {
    ""prompt_tokens"": 1000,
    ""completion_tokens"": 800,
    ""total_tokens"": 1800,
    ""completion_tokens_details"": {
        ""reasoning_tokens"": 50,
        ""context_tokens"": 20
    }
  }
}";
    }
}
