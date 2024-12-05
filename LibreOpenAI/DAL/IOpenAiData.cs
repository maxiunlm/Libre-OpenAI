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
        Task<dynamic> GetChatGptResponseDynamic(IRequestBody request);
        Task<dynamic> GetChatGptResponseDynamic(dynamic request);
        Task<dynamic> GetChatGptResponseDynamic(string requestJson);
        Task<string> GetChatGptResponseJson(IRequestBody request);
        Task<string> GetChatGptResponseJson(dynamic request);
        Task<string> GetChatGptResponseJson(string requestJson);
        Task<List<IChatCompletionChunk>> GetChatGptStreamingResponse(IRequestBody request);
        Task<List<IChatCompletionChunk>> GetChatGptStreamingResponse(dynamic request);
        Task<List<IChatCompletionChunk>> GetChatGptStreamingResponse(string request);
        Task<dynamic> GetChatGptStreamingResponseDynamic(IRequestBody request);
        Task<dynamic> GetChatGptStreamingResponseDynamic(dynamic request);
        Task<dynamic> GetChatGptStreamingResponseDynamic(string requestJson);
        Task<string> GetChatGptStreamingResponseJson(IRequestBody request);
        Task<string> GetChatGptStreamingResponseJson(dynamic request);
        Task<string> GetChatGptStreamingResponseJson(string requestJson);
    }
}