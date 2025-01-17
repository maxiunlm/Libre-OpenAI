using LibreOpenAI.OpenAi.AudioAi;
using LibreOpenAI.OpenAi.BatchesAi;
using LibreOpenAI.OpenAi.ChatAi;
using LibreOpenAI.OpenAi.EmbeddingsAi;
using LibreOpenAI.OpenAi.FineTuningAi;
using LibreOpenAI.OpenAi.ImagesAi;
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
            Batches = new Batches(settings);
            Audio = new Audio(settings);
            Images = new Images(settings);
        }

        public OpenAI(string openAiApiKey)
        {
            settings = new OpenAiSettings(openAiApiKey);
            Chat = new Chat(settings);
            FineTuning = new FineTuning(settings);
            Embeddings = new Embeddings(settings);
            Batches = new Batches(settings);
            Audio = new Audio(settings);
            Images = new Images(settings);
        }

        public OpenAI(OpenAiSettings settings)
        {
            this.settings = settings ?? new OpenAiSettings();
            Chat = new Chat(this.settings);
            FineTuning = new FineTuning(this.settings);
            Embeddings = new Embeddings(this.settings);
            Batches = new Batches(settings);
            Audio = new Audio(settings);
            Images = new Images(settings);
        }

        public IChat Chat { get; set; }
        public IFineTuning FineTuning { get; set; }
        public IEmbeddings Embeddings { get; set; }
        public IBatches Batches { get; set; }
        public IAudio Audio { get; set; }
        public IImages Images { get; set; }
    }
}
