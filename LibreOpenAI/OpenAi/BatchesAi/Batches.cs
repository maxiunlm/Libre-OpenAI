using LibreOpenAI.Base.Creation;
using LibreOpenAI.OpenAi.Settings;

namespace LibreOpenAI.OpenAi.BatchesAi
{
    public class Batches : CreationBase, IBatches
    {
        public Batches(IOpenAiSettings settings) : base(settings, settings.OpenAiUrl)
        {
        }

        // TODO: Unit Tests !!!!!!!!!!!!!!!!!!!!!!!!

        public async Task<string> RetrieveJson(string fineTuningJobId)
        {
            string url = settings.OpenAiUrlFileTuningJobsRetrieve.ToString().Replace("{fine_tuning_job_id}", fineTuningJobId);
            Uri openAiUrl = new Uri(url);
            string response = await OpenAiData.GetChatGptResponseJson(openAiUrl);
            return response;
        }

    }
}
