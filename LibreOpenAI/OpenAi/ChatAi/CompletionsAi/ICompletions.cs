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
        /// <param name="request">The request parame is IRequestBody type</param>
        /// <returns>Returns a chat completion object.</returns>
        /// <remarks>If you want to create a streaming completion, you must use 'Completions.CreateStream' instead of 'Completions.Create'.</remarks>
        /// <remarks>The request stream must NOT be on true: request.stream = false // null or undefined</remarks>
        /// <see cref="https://api.openai.com/v1/chat/completions"/>
        /// <seealso cref="https://platform.openai.com/docs/api-reference/chat/object"/>
        /// <seealso cref="https://platform.openai.com/docs/api-reference/chat/streaming"/>
        Task<IChatCompletionResponse> Create(IRequestBody request);
        /// <summary>
        /// Creates a model response for the given chat conversation.
        /// </summary>
        /// <param name="request">The request parame is dynamic type</param>
        /// <returns>Returns a chat completion object.</returns>
        /// <remarks>If you want to create a streaming completion, you must use 'Completions.CreateStream' instead of 'Completions.Create'.</remarks>
        /// <remarks>The request stream must NOT be on true: request.stream = false // null or undefined</remarks>
        /// <see cref="https://api.openai.com/v1/chat/completions"/>
        /// <seealso cref="https://platform.openai.com/docs/api-reference/chat/object"/>
        /// <seealso cref="https://platform.openai.com/docs/api-reference/chat/streaming"/>
        Task<IChatCompletionResponse> Create(dynamic request);
        /// <summary>
        /// Creates a model response for the given chat conversation.
        /// </summary>
        /// <param name="requestJson">The request parame must be a JSON string</param>
        /// <returns>Returns a chat completion object.</returns>
        /// <remarks>If you want to create a streaming completion, you must use 'Completions.CreateStream' instead of 'Completions.Create'.</remarks>
        /// <remarks>The request stream must NOT be on true: request.stream = false // null or undefined</remarks>
        /// <see cref="https://api.openai.com/v1/chat/completions"/>
        /// <seealso cref="https://platform.openai.com/docs/api-reference/chat/object"/>
        /// <seealso cref="https://platform.openai.com/docs/api-reference/chat/streaming"/>
        Task<IChatCompletionResponse> Create(string requestJson);
        Task<dynamic> CreateDynamic(IRequestBody request);
        Task<dynamic> CreateDynamic(dynamic request);
        Task<dynamic> CreateDynamic(string requestJson);
        Task<string> CreateJson(IRequestBody request);
        Task<string> CreateJson(dynamic request);
        Task<string> CreateJson(string requestJson);

        /// <summary>
        /// Creates a model response for the given chat conversation.
        /// </summary>
        /// <param name="request">The request parame is IRequestBody type</param>
        /// <returns>Returns a streamed sequence of chat completion chunk objects if the request is streamed.</returns>
        /// <remarks>If you want to create a streaming completion, you must use 'Completions.CreateStream' instead of 'Completions.Create'.</remarks>
        /// <remarks>The request stream must be on true: request.stream = true</remarks>
        /// <see cref="https://api.openai.com/v1/chat/completions"/>
        /// <seealso cref="https://platform.openai.com/docs/api-reference/chat/object"/>
        /// <seealso cref="https://platform.openai.com/docs/api-reference/chat/streaming"/>
        Task<List<IChatCompletionChunk>> CreateStream(IRequestBody request);
        /// <summary>
        /// Creates a model response for the given chat conversation.
        /// </summary>
        /// <param name="request">The request parame is dynamic type</param>
        /// <returns>Returns a streamed sequence of chat completion chunk objects if the request is streamed.</returns>
        /// <remarks>If you want to create a streaming completion, you must use 'Completions.CreateStream' instead of 'Completions.Create'.</remarks>
        /// <remarks>The request stream must be on true: request.stream = true</remarks>
        /// <see cref="https://api.openai.com/v1/chat/completions"/>
        /// <seealso cref="https://platform.openai.com/docs/api-reference/chat/object"/>
        /// <seealso cref="https://platform.openai.com/docs/api-reference/chat/streaming"/>
        Task<List<IChatCompletionChunk>> CreateStream(dynamic request);
        /// <summary>
        /// Creates a model response for the given chat conversation.
        /// </summary>
        /// <param name="requestJson">The request parame must be a JSON string</param>
        /// <returns>Returns a streamed sequence of chat completion chunk objects if the request is streamed.</returns>
        /// <remarks>If you want to create a streaming completion, you must use 'Completions.CreateStream' instead of 'Completions.Create'.</remarks>
        /// <remarks>The request stream must be on true: request.stream = true</remarks>
        /// <see cref="https://api.openai.com/v1/chat/completions"/>
        /// <seealso cref="https://platform.openai.com/docs/api-reference/chat/object"/>
        /// <seealso cref="https://platform.openai.com/docs/api-reference/chat/streaming"/>
        Task<List<IChatCompletionChunk>> CreateStream(string requestJson);
        Task<dynamic> CreateStreamDynamic(IRequestBody request);
        Task<dynamic> CreateStreamDynamic(dynamic request);
        Task<dynamic> CreateStreamDynamic(string requestJson);
        Task<string> CreateStreamJson(IRequestBody request, bool raw = false);
        Task<string> CreateStreamJson(dynamic request, bool raw = false);
        Task<string> CreateStreamJson(string requestJson, bool raw = false);
    }
}