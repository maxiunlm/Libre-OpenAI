using LibreOpenAI.DAL.Http;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response;
using Newtonsoft.Json.Linq;

namespace LibreOpenAI.DAL
{
    public interface IOpenAiData
    {
        IHttpClientAi Client { get; set; }

        Task<IChatCompletionResponse> GetChatGptResponse(IRequestBody request);
        Task<IChatCompletionResponse> GetChatGptResponse(dynamic request);
        Task<IChatCompletionResponse> GetChatGptResponse(string request);
        Task<JToken> GetChatGptResponseJToken(IRequestBody request);
        Task<JToken> GetChatGptResponseJToken(dynamic request);
        Task<JToken> GetChatGptResponseJToken(string requestJson);
        Task<dynamic> GetChatGptResponseDynamic(IRequestBody request); // TODO: Unit Tests.
        Task<dynamic> GetChatGptResponseDynamic(dynamic request); // TODO: Unit Tests.
        Task<dynamic> GetChatGptResponseDynamic(string requestJson); // TODO: Unit Tests.
        Task<string> GetChatGptResponseJson(IRequestBody request);
        Task<string> GetChatGptResponseJson(dynamic request);
        Task<string> GetChatGptResponseJson(string requestJson);
        Task<List<IChatCompletionChunk>> GetChatGptStreamingResponse(IRequestBody request);
        Task<List<IChatCompletionChunk>> GetChatGptStreamingResponse(dynamic request);
        Task<List<IChatCompletionChunk>> GetChatGptStreamingResponse(string request);
        Task<JToken> GetChatGptStreamingResponseJToken(IRequestBody request);
        Task<JToken> GetChatGptStreamingResponseJToken(dynamic request);
        Task<JToken> GetChatGptStreamingResponseJToken(string requestJson);
        Task<dynamic> GetChatGptStreamingResponseDynamic(IRequestBody request); // TODO: Unit Tests.
        Task<dynamic> GetChatGptStreamingResponseDynamic(dynamic request); // TODO: Unit Tests.
        Task<dynamic> GetChatGptStreamingResponseDynamic(string requestJson); // TODO: Unit Tests.
        Task<string> GetChatGptStreamingResponseJson(IRequestBody request, bool raw);
        Task<string> GetChatGptStreamingResponseJson(dynamic request, bool raw);
        Task<string> GetChatGptStreamingResponseJson(string requestJson, bool raw);
    }
}