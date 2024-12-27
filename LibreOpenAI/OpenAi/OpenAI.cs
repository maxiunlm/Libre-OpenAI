using LibreOpenAI.OpenAi.ChatAi;
using LibreOpenAI.OpenAi.EmbeddingsAi;
using LibreOpenAI.OpenAi.FineTuningAi;
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
            FineTuning = new FineTuning(settings);
            Embeddings = new Embeddings(settings);
        }

        public OpenAI(string openAiApiKey)
        {
            settings = new OpenAiSettings(openAiApiKey);
            Chat = new Chat(settings);
            FineTuning = new FineTuning(settings);
            Embeddings = new Embeddings(settings);
        }

        public OpenAI(OpenAiSettings settings)
        {
            this.settings = settings ?? new OpenAiSettings();
            Chat = new Chat(this.settings);
            FineTuning = new FineTuning(this.settings);
            Embeddings = new Embeddings(this.settings);
        }
        public IChat Chat { get; set; }
        public IFineTuning FineTuning { get; set; }
        public IEmbeddings Embeddings { get; set; }
    }
}
