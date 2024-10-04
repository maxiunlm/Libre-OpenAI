using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Logprobs;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Message;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices
{
    public class ChoiceResponse : IChoiceResponse
    {
        public string FinishReason { get; set; } = string.Empty;
        public int Index { get; set; }
        public IMessageChoiseResponse Message { get; set; } = new MessageChoiseResponse();
        public ILogprobsChoiseResponse? Logprobs { get; set; }
    }
}
