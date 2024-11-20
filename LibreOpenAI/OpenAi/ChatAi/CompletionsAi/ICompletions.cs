using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests;
using LibreOpenAI.DAL;

namespace LibreOpenAI.OpenAi.ChatAi.CompletionsAi
{
    public interface ICompletions
    {
        IOpenAiData OpenAiData { get; set; }
        /// <summary>
        /// Creates a model response for the given chat conversation.
        /// </summary>
        /// <returns>Returns a chat completion object.</returns>
        /// <remarks>If you want to create a streaming completion, you must use 'Completions.CreateStream' instead of 'Completions.Create'.</remarks>
        /// <see cref="https://api.openai.com/v1/chat/completions"/>
        /// <seealso cref="https://platform.openai.com/docs/api-reference/chat/object"/>
        /// <seealso cref="https://platform.openai.com/docs/api-reference/chat/streaming"/>
        Task<IChatCompletionResponse> Create(IRequestBody request);

        /// <summary>
        /// Creates a model response for the given chat conversation.
        /// </summary>
        /// <returns>Returns a streamed sequence of chat completion chunk objects if the request is streamed.</returns>
        /// <remarks>If you want to create a streaming completion, you must use 'Completions.CreateStream' instead of 'Completions.Create'.</remarks>
        /// <see cref="https://api.openai.com/v1/chat/completions"/>
        /// <seealso cref="https://platform.openai.com/docs/api-reference/chat/object"/>
        /// <seealso cref="https://platform.openai.com/docs/api-reference/chat/streaming"/>
        Task<List<IChatCompletionChunk>> CreateStream(IRequestBody request);
    }
}