namespace LibreOpenAIUnitTestProject.Fakes
{
    internal static class ResponseFakes
    {
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
    }
}
