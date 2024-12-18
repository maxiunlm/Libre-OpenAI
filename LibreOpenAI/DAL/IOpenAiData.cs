using LibreOpenAI.DAL.Http;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response;

namespace LibreOpenAI.DAL
{
    public interface IOpenAiData
    {
        IHttpClientAi Client { get; set; }
        Task<string> GetChatGptResponseJson(string requestJson);
        Task<string> GetChatGptStreamingResponseJson(string requestJson, bool raw);
        Task<List<IChatCompletionChunk>> GetChatGptStreamingResponse(string requestJson);
    }
}