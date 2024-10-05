using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Logprobs.Content;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Logprobs.Refusal;
using Microsoft.VisualBasic;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Logprobs
{
    public class LogprobsChoiseResponse : ILogprobsChoiseResponse
    {
        public List<ContentLogprobsChoiseResponse> Content { get; set; } = new List<ContentLogprobsChoiseResponse>();

        public List<RefusalLogprobsChoiseResponse> Refusal { get; set; } = new List<RefusalLogprobsChoiseResponse>();
    }
}
