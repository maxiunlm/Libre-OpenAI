using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Logprobs.Content;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Logprobs.Refusal;
using Microsoft.VisualBasic;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Logprobs
{
    public class LogprobsChoiseResponse : ILogprobsChoiseResponse
    {
        public List<IContentLogprobsChoiseResponse> Content { get; set; } = new List<IContentLogprobsChoiseResponse>();

        public List<IRefusalLogprobsChoiseResponse> Refusal { get; set; } = new List<IRefusalLogprobsChoiseResponse>();
    }
}
