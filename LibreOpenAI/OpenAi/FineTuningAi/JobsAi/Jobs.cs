using LibreOpenAI.Base.Creation;
using LibreOpenAI.OpenAi.Settings;
using Newtonsoft.Json.Linq;

namespace LibreOpenAI.OpenAi.FineTuningAi.JobsAi
{
    public class Jobs : CreationBase, IJobs
    {
        public Jobs(IOpenAiSettings settings) : base(settings, settings.OpenAiUrlFileTuningJobs)
        {
        }

        // TODO: Unit Tests !!!!!!!!!!!!!!!!!!!!!!!!
        // TODO: CURL: public Uri OpenAiUrlFileTuningCheckpoints Extension !!!!!!!!!!!!!!!!!!!!!!!!

        public async Task<dynamic> ListDynamic(int limit = 20, string after = "")
        {
            string responseBody = await ListJson(limit, after);
            dynamic response = JToken.Parse(responseBody);
            return response;
        }

        public async Task<string> ListJson(int limit = 20, string after = "")
        {
            string afterParam = string.IsNullOrWhiteSpace(after) ? string.Empty : $"&after={after}";
            Uri openAiUrl = new Uri($"{settings.OpenAiUrlFileTuningJobs.ToString()}?limit={limit}{afterParam}");
            string response = await OpenAiData.GetChatGptResponseJson(openAiUrl);
            return response;
        }

        public async Task<dynamic> ListEventsDynamic(string fineTuningJobId, int limit = 20, string after = "")
        {
            string responseBody = await ListEventsJson(fineTuningJobId, limit, after);
            dynamic response = JToken.Parse(responseBody);
            return response;
        }

        public async Task<string> ListEventsJson(string fineTuningJobId, int limit = 20, string after = "")
        {
            string afterParam = string.IsNullOrWhiteSpace(after) ? string.Empty : $"&after={after}";
            string url = settings.OpenAiUrlFileTuningEvents.ToString().Replace("{fine_tuning_job_id}", fineTuningJobId);
            Uri openAiUrl = new Uri($"{url}?limit={limit}{afterParam}");
            string response = await OpenAiData.GetChatGptResponseJson(openAiUrl);
            return response;
        }

        public async Task<dynamic> RetrieveDynamic(string fineTuningJobId)
        {
            string responseBody = await RetrieveJson(fineTuningJobId);
            dynamic response = JToken.Parse(responseBody);
            return response;
        }

        public async Task<string> RetrieveJson(string fineTuningJobId)
        {
            string url = settings.OpenAiUrlFileTuningJobsRetrieve.ToString().Replace("{fine_tuning_job_id}", fineTuningJobId);
            Uri openAiUrl = new Uri(url);
            string response = await OpenAiData.GetChatGptResponseJson(openAiUrl);
            return response;
        }

        public async Task<dynamic> CancelDynamic(string fineTuningJobId)
        {
            string responseBody = await CancelJson(fineTuningJobId);
            dynamic response = JToken.Parse(responseBody);
            return response;
        }

        public async Task<string> CancelJson(string fineTuningJobId)
        {
            string url = settings.OpenAiUrlFileTuningJobsCancel.ToString().Replace("{fine_tuning_job_id}", fineTuningJobId);
            Uri openAiUrl = new Uri(url);
            string response = await OpenAiData.PostChatGptResponseJson(string.Empty, openAiUrl);
            return response;
        }
    }
}
