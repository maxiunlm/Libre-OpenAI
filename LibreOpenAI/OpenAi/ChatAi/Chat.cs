using LibreOpenAI.OpenAi.ChatAi.CompletionsAi;
using LibreOpenAI.OpenAi.Settings;

namespace LibreOpenAI.OpenAi.ChatAi
{
    public class Chat : IChat
    {
        public Chat(IOpenAiSettings settings)
        {
            Completions = new Completions(settings);
        }

        public ICompletions Completions { get; set; }
    }
}
