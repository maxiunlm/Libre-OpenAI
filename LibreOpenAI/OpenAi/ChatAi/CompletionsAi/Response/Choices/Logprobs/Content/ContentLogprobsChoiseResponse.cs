using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Logprobs.Content.TopLogprobs;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Logprobs.Content
{
    public class ContentLogprobsChoiseResponse : IContentLogprobsChoiseResponse
    {
        public const decimal defultLogprob = -9999.0m;
        public string Token { get; set; } = string.Empty;
        public decimal Logprob { get; set; } = defultLogprob;
        public List<int>? Bytes { get; set; }
        public List<ITopLogprobsChoiseResponse> TopLogprobs { get; set; } = new List<ITopLogprobsChoiseResponse>();
    }
}
