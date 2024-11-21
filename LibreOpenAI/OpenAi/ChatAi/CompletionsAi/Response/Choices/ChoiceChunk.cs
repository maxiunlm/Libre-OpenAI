using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Delta;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices.Logprobs;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices
{
    public class ChoiceChunk : IChoiceChunk
    {
        public int Index { get; set; }
        public DeltaChunk Delta { get; set; }
        public LogprobsChoiseChunk? Logprobs { get; set; }
        public string FinishReason { get; set; }
    }
}
