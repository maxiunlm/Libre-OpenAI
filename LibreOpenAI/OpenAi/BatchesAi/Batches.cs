using LibreOpenAI.Base.Creation;
using LibreOpenAI.OpenAi.Settings;
using Newtonsoft.Json.Linq;
namespace LibreOpenAI.OpenAi.BatchesAi
{
    public class Batches : CreationBase, IBatches
    {
        public Batches(IOpenAiSettings settings) : base(settings, settings.OpenAiUrlBatches)
        {
        }

        // TODO: Unit Tests !!!!!!!!!!!!!!!!!!!!!!!!

        public async Task<dynamic> RetrieveDynamic(string batchId)
        {
            string responseBody = await RetrieveDynamic(batchId);
            dynamic response = JToken.Parse(responseBody);
            return response;
        }

        public async Task<string> RetrieveJson(string batchId)
        {
            string url = settings.OpenAiUrlBatchesRetrieve.ToString().Replace("{batch_id}", batchId);
            Uri openAiUrl = new Uri(url);
            string response = await OpenAiData.GetChatGptResponseJson(openAiUrl);
            return response;
        }

        public async Task<dynamic> CancelDynamic(string batchId)
        {
            string responseBody = await CancelDynamic(batchId);
            dynamic response = JToken.Parse(responseBody);
            return response;
        }

        public async Task<string> CancelJson(string batchId)
        {
            string url = settings.OpenAiUrlBatchesCancel.ToString().Replace("{batch_id}", batchId);
            Uri openAiUrl = new Uri(url);
            string response = await OpenAiData.PostChatGptResponseJson(string.Empty, openAiUrl);
            return response;
        }

        public async Task<dynamic> ListDynamic(int limit = 20, string after = "")
        {
            string responseBody = await ListJson(limit, after);
            dynamic response = JToken.Parse(responseBody);
            return response;
        }

        public async Task<string> ListJson(int limit = 20, string after = "")
        {
            string afterParam = string.IsNullOrWhiteSpace(after) ? string.Empty : $"&after={after}";
            Uri openAiUrl = new Uri($"{settings.OpenAiUrlBatches.ToString()}?limit={limit}{afterParam}");
            string response = await OpenAiData.GetChatGptResponseJson(openAiUrl);
            return response;
        }
    }
}
