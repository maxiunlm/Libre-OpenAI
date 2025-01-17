using LibreOpenAI.DAL;

namespace LibreOpenAI.OpenAi.ImagesAi
{
    public interface IImages
    {
        IOpenAiData OpenAiData { get; set; }

        Task<dynamic> CreateVariationDynamic(dynamic request);
        Task<dynamic> CreateVariationDynamic(string requestJson);
        Task<string> CreateVariationJson(dynamic request);
        Task<string> CreateVariationJson(string requestJson);
        Task<string> CreateVariationJson(string requestJson, Uri openAiUrl);
        Task<dynamic> EditDynamic(dynamic request);
        Task<dynamic> EditDynamic(string requestJson);
        Task<string> EditJson(dynamic request);
        Task<string> EditJson(string requestJson);
        Task<string> EditJson(string requestJson, Uri openAiUrl);
        Task<dynamic> GenerateDynamic(dynamic request);
        Task<dynamic> GenerateDynamic(string requestJson);
        Task<string> GenerateJson(dynamic request);
        Task<string> GenerateJson(string requestJson);
        Task<string> GenerateJson(string requestJson, Uri openAiUrl);
    }
}