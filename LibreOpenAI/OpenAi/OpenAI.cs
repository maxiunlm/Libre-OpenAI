using LibreOpenAI.OpenAi.ChatAi;
using LibreOpenAI.OpenAi.Settings;

namespace LibreOpenAI.OpenAi
{
    public class OpenAI : IOpenAI
    {
        private readonly IOpenAiSettings settings;

        public OpenAI()
        {
            settings = new OpenAiSettings();
            Chat = new Chat(settings);
        }

        public OpenAI(string openAiApiKey)
        {
            settings = new OpenAiSettings(openAiApiKey);
            Chat = new Chat(settings);
        }

        public OpenAI(OpenAiSettings settings)
        {
            this.settings = settings ?? new OpenAiSettings();
            Chat = new Chat(this.settings);
        }

        public IChat Chat { get; set; }
    }
}
