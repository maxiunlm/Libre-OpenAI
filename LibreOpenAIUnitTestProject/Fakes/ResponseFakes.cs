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
    }
}
