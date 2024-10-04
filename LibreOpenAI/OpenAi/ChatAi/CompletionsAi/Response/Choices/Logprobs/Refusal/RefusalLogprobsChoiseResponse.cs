using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Logprobs.Content;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Logprobs.Content.TopLogprobs;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Logprobs.Refusal
{
    public class RefusalLogprobsChoiseResponse : IRefusalLogprobsChoiseResponse
    {
        public string Token { get; set; } = string.Empty;
        public decimal Logprob { get; set; } = ContentLogprobsChoiseResponse.defultLogprob;
        public List<int>? Bytes { get; set; }
        public List<ITopLogprobsChoiseResponse> TopLogprobs { get; set; } = new List<ITopLogprobsChoiseResponse>();
    }
}
