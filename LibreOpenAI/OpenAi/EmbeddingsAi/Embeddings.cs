using LibreOpenAI.Base.Creation;
using LibreOpenAI.OpenAi.Settings;

namespace LibreOpenAI.OpenAi.EmbeddingsAi
{
    public class Embeddings : CreationBase
    {
        public Embeddings(IOpenAiSettings settings) : base(settings, settings.OpenAiUrlEmbeddings)
        {
        }

        // TODO: Unit Tests !!!!!!!!!!!!!!!!!!!!!!!!
    }
}
