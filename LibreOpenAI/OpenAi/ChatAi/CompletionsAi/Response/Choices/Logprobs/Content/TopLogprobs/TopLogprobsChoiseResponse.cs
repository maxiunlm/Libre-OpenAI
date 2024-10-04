using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Logprobs.Content;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Logprobs.Content.TopLogprobs
{
    public class TopLogprobsChoiseResponse : ITopLogprobsChoiseResponse
    {
        public List<int>? Bytes { get; set; }
        public decimal Logprob { get; set; } = ContentLogprobsChoiseResponse.defultLogprob;
        public string Token { get; set; } = string.Empty;
    }
}
