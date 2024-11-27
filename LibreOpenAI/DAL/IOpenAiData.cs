using LibreOpenAI.DAL.Http;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response;

namespace LibreOpenAI.DAL
{
    public interface IOpenAiData
    {
        IHttpClientAi Client { get; set; }

        Task<IChatCompletionResponse> GetChatGptResponse(IRequestBody request);
        Task<IChatCompletionResponse> GetChatGptResponse(dynamic request);
        Task<IChatCompletionResponse> GetChatGptResponse(string request);
        Task<List<IChatCompletionChunk>> GetChatGptStreamingResponse(IRequestBody request);
        Task<List<IChatCompletionChunk>> GetChatGptStreamingResponse(dynamic request);
        Task<List<IChatCompletionChunk>> GetChatGptStreamingResponse(string request);
    }
}