using LibreOpenAI.OpenAi.ChatAi;
using LibreOpenAI.OpenAi.EmbeddingsAi;
using LibreOpenAI.OpenAi.FineTuningAi;
using Newtonsoft.Json;

namespace LibreOpenAI.OpenAi
{
    /// <summary>
    /// Libre C# version
    /// </summary>
    /// <see cref="https://platform.openai.com/docs/api-reference/introduction"/>
    public interface IOpenAI
    {
        /// <summary>
        /// Given a list of messages comprising a conversation, the model will return a response.
        /// </summary>
        /// <see cref="https://platform.openai.com/docs/api-reference/chat"/>
        /// <see cref="https://platform.openai.com/docs/guides/text-generation"/>
        [JsonProperty("chat")]
        IChat Chat { get; set; }
        /// <summary>
        /// Get a vector representation of a given input that can be easily consumed by machine learning models and algorithms. Related guide: Embeddings
        /// </summary>
        /// <see cref="https://platform.openai.com/docs/api-reference/embeddings"/>
        /// <see cref="https://platform.openai.com/docs/guides/embeddings"/>
        [JsonProperty("embeddings")]
        IEmbeddings Embeddings { get; set; }
        /// <summary>
        /// Manage fine-tuning jobs to tailor a model to your specific training data. Related guide: Fine-tune models
        /// </summary>
        /// <see cref="https://platform.openai.com/docs/api-reference/fine-tuning"/>
        /// <see cref="https://platform.openai.com/docs/guides/fine-tuning"/>
        [JsonProperty("fineTuning")]
        IFineTuning FineTuning { get; set; }
    }
}