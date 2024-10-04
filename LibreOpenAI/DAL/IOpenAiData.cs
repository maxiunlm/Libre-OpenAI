using LibreOpenAI.DAL.Http;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Requests;
using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response;

namespace LibreOpenAI.DAL
{
    public interface IOpenAiData
    {
        IHttpClientAi Client { get; set; }

        Task<IChatCompletionResponse> GetChatGptResponse(IRequestBody request);
    }
}