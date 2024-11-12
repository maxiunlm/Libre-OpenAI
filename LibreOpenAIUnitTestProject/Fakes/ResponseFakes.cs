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
      ""message"": { ""role"": ""assistant"", ""content"": """ + testForMultipleChoicesResponseFirst + @"""},
      ""logprobs"": null,
      ""finish_reason"": ""stop""
    },
    {
      ""index"": 1,
      ""message"": { ""role"": ""assistant"", ""content"": """ + testForMultipleChoicesResponseSecond + @"""},
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
        public const string testTruncatedResponse = "Can you provide a detailed explanation about how machine learning algorithms work?";
        public const string thisResponseWasCutShort = "This response was cut short...";
        public const string truncatedResponseJson = @"{
  ""id"": ""chatcmpl-789"",
  ""object"": ""chat.completion"",
  ""created"": 1677652295,
  ""model"": ""gpt-4o-long"",
  ""choices"": [{
    ""index"": 0,
    ""message"": { ""role"": ""assistant"", ""content"": """ + thisResponseWasCutShort + @"""},
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
        public const string hereIAResponseWithLogprobs = "Here's a response with logprobs.";
        public const string logprobsResponseJson = @"{
  ""id"": ""chatcmpl-101"",
  ""object"": ""chat.completion"",
  ""created"": 1677652299,
  ""model"": ""gpt-4o-log"",
  ""choices"": [{
    ""index"": 0,
    ""message"": { ""role"": ""assistant"", ""content"": """ + hereIAResponseWithLogprobs + @"""},
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
        public const string testHighTokenUsageResponse = "Generate a long response to test high token usage.";
        public const string hereIsALongResponseToTestHighTokenUsage = "Here's a long response to test high token usage.";
        public const string highTokenUsageResponseJson = @"{
  ""id"": ""chatcmpl-303"",
  ""object"": ""chat.completion"",
  ""created"": 1677652300,
  ""model"": ""gpt-4o-heavy"",
  ""choices"": [{
    ""index"": 0,
    ""message"": { ""role"": ""assistant"", ""content"": """ + hereIsALongResponseToTestHighTokenUsage + @"""},
    ""logprobs"": null,
    ""finish_reason"": ""stop""
  }],
  ""usage"": {
    ""prompt_tokens"": 1000,
    ""completion_tokens"": 800,
    ""total_tokens"": 1800
  }
}";
        public const string testEmptyChoicesResponse = "";
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
        public const string testAStandardCompletionResponseFromChatGpt = "Say hello.";
        public const string aStandardCompletionResponseFromChat = "Hello!";
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
        ""content"": """ + aStandardCompletionResponseFromChat + @"""
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
        public const string testLogprobsResponseWithTextOffset = "Generate a response with logprobs.";
        public const string logprobsResponseWithTextOffset = "Here's a response with logprobs and text offsets.";
        public const string logprobsResponseWithTextOffsetJson = @"{
  ""id"": ""chatcmpl-101"",
  ""object"": ""chat.completion"",
  ""created"": 1677652299,
  ""model"": ""gpt-4o-log"",
  ""choices"": [{
    ""index"": 0,
    ""message"": { ""role"": ""assistant"", ""content"": """ + logprobsResponseWithTextOffset + @"""},
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
        public const string testFunctionCallFinishReasonSystem = "You are an assistant.";
        public const string testFunctionCallFinishReasonUser = "Please provide a response with logprobs and text offsets.";
        public const string functionCallFinishReason = "Sure, please provide the text for which you would like me to generate a response with logprobs and text offsets.";
        public const string functionCallFinishReasonJson = @"{
  ""id"": ""chatcmpl-789"",
  ""object"": ""chat.completion"",
  ""created"": 1677652295,
  ""model"": ""gpt-4o-long"",
  ""choices"": [{
    ""index"": 0,
    ""message"": { ""role"": ""assistant"", ""content"": """ + functionCallFinishReason + @"""},
    ""logprobs"": null,
    ""finish_reason"": ""function_call""
  }],
  ""usage"": {
    ""prompt_tokens"": 20,
    ""completion_tokens"": 5,
    ""total_tokens"": 25
  }
}";
        public const string testDtailedTokenUsageResponseSystem = "You are an assistant that provides detailed token usage.";
        public const string testDetailedTokenUsageResponseUser = "Please provide a response that includes detailed token usage.";
        public const string detailedTokenUsageResponse = "This response includes detailed token usage.";
        public const string detailedTokenUsageResponseJson = @"{
  ""id"": ""chatcmpl-303"",
  ""object"": ""chat.completion"",
  ""created"": 1677652300,
  ""model"": ""gpt-4o-heavy"",
  ""choices"": [{
    ""index"": 0,
    ""message"": { ""role"": ""assistant"", ""content"": """ + detailedTokenUsageResponse + @"""},
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
