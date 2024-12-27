using LibreOpenAI.DAL.Http;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response;

namespace LibreOpenAI.DAL
{
    public interface IOpenAiData
    {
        IHttpClientAi Client { get; set; }
        Task<string> GetChatGptResponseJson(Uri url);
        Task<string> PostChatGptResponseJson(string requestJson, Uri url);
        Task<string> PostChatGptStreamingResponseJson(string requestJson, bool raw);
        Task<List<IChatCompletionChunk>> PostChatGptStreamingResponse(string requestJson);
    }
}