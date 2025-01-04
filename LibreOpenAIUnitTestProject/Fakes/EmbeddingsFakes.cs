namespace LibreOpenAIUnitTestProject.Fakes
{
    internal class EmbeddingsFakes
    {
        public const string resquestCreate = @"{
    model: ""text-embedding-ada-002"",
    input: ""The quick brown fox jumped over the lazy dog"",
    encoding_format: ""float"",
}";
        public const string responseCreate = @"{
  ""object"": ""list"",
  ""data"": [
    {
      ""object"": ""embedding"",
      ""embedding"": [
        0.0023064255,
        -0.009327292,
        -0.0028842222,
      ],
      ""index"": 0
    }
  ],
  ""model"": ""text-embedding-ada-002"",
  ""usage"": {
    ""prompt_tokens"": 8,
    ""total_tokens"": 8
  }
}";
    }
}
