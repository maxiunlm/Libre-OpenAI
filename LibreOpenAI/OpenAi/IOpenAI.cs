using LibreOpenAI.OpenAi.BatchesAi;
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
        /// <seealso cref="https://platform.openai.com/docs/guides/text-generation"/>
        [JsonProperty("chat")]
        IChat Chat { get; set; }
        /// <summary>
        /// Get a vector representation of a given input that can be easily consumed by machine learning models and algorithms. Related guide: Embeddings
        /// </summary>
        /// <see cref="https://platform.openai.com/docs/api-reference/embeddings"/>
        /// <seealso cref="https://platform.openai.com/docs/guides/embeddings"/>
        [JsonProperty("embeddings")]
        IEmbeddings Embeddings { get; set; }
        /// <summary>
        /// Manage fine-tuning jobs to tailor a model to your specific training data. Related guide: Fine-tune models
        /// </summary>
        /// <see cref="https://platform.openai.com/docs/api-reference/fine-tuning"/>
        /// <seealso cref="https://platform.openai.com/docs/guides/fine-tuning"/>
        [JsonProperty("fineTuning")]
        IFineTuning FineTuning { get; set; }
        /// <summary>
        /// Create large batches of API requests for asynchronous processing. The Batch API returns completions within 24 hours for a 50% discount. Related guide: Batch
        /// </summary>
        /// <see cref="https://platform.openai.com/docs/api-reference/batch/create"/>
        /// <seealso cref="https://platform.openai.com/docs/guides/batch"/>
        [JsonProperty("batches")]
        IBatches Batches { get; set; }
    }
}