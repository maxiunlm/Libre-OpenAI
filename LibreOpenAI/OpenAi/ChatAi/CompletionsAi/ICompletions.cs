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
        /// <returns>Returns a chat completion object, or a streamed sequence of chat completion chunk objects if the request is streamed.</returns>
        /// <see cref="https://api.openai.com/v1/chat/completions"/>
        /// <seealso cref="https://platform.openai.com/docs/api-reference/chat/object"/>
        /// <seealso cref="https://platform.openai.com/docs/api-reference/chat/streaming"/>
        Task<IChatCompletionResponse> Create(IRequestBody request);
    }
}