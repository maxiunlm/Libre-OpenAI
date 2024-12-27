using LibreOpenAI.DAL;

namespace LibreOpenAI.Base.Creation
{
    public interface ICreationBase
    {
        IOpenAiData OpenAiData { get; set; }

        Task<dynamic> CreateDynamic(dynamic request);
        Task<dynamic> CreateDynamic(string requestJson);
        Task<string> CreateJson(dynamic request);
        Task<string> CreateJson(string requestJson);
        Task<string> CreateJson(string requestJson, Uri openAiUrl);
    }
}