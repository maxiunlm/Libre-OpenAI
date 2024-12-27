using LibreOpenAI.Base.Creation;
using LibreOpenAI.OpenAi.Settings;

namespace LibreOpenAI.OpenAi.FineTuningAi.JobsAi
{
    public class Jobs : CreationBase, IJobs
    {
        public Jobs(IOpenAiSettings settings) : base(settings, settings.OpenAiUrlFileTuningJobs)
        {
        }

        // TODO: Unit Tests !!!!!!!!!!!!!!!!!!!!!!!!
        // TODO: CURL: public Uri OpenAiUrlFileTuningCheckpoints Extension !!!!!!!!!!!!!!!!!!!!!!!!

        /// <summary>
        /// List your organization's fine-tuning jobs.
        /// </summary>
        /// <param name="limit">Number of fine-tuning jobs to retrieve. Optional query parameter. Defaults to 20.</param>
        /// <param name="after">Identifier for the last job from the previous pagination request. Optional query parameter.</param>
        /// <returns>A list of paginated fine-tuning job objects.</returns>
        /// <see cref="https://platform.openai.com/docs/api-reference/fine-tuning/list"/>
        /// <see cref="https://platform.openai.com/docs/api-reference/fine-tuning/object"/>
        public async Task<string> ListJson(int limit = 20, string after = "")
        {
            string afterParam = string.IsNullOrWhiteSpace(after) ? string.Empty : $"&after={after}";
            Uri openAiUrl = new Uri($"{settings.OpenAiUrlFileTuningJobs.ToString()}?limit={limit}{afterParam}");
            string response = await OpenAiData.GetChatGptResponseJson(openAiUrl);
            return response;
        }

        /// <summary>
        /// Get status updates for a fine-tuning job.
        /// </summary>
        /// <param name="fineTuningJobId">Number of fine-tuning jobs to retrieve. Required path parameter.</param>
        /// <param name="limit">Number of events to retrieve. Optional query parameter. Defaults to 20.</param>
        /// <param name="after">Identifier for the last event from the previous pagination request. Optional query parameter.</param>
        /// <returns>A list of fine-tuning event objects.</returns>
        /// <see cref="https://platform.openai.com/docs/api-reference/fine-tuning/list-events"/>
        public async Task<string> ListEventsJson(string fineTuningJobId, int limit = 20, string after = "")
        {
            string afterParam = string.IsNullOrWhiteSpace(after) ? string.Empty : $"&after={after}";
            string url = settings.OpenAiUrlFileTuningEvents.ToString().Replace("{fine_tuning_job_id}", fineTuningJobId);
            Uri openAiUrl = new Uri($"{url}?limit={limit}{afterParam}");
            string response = await OpenAiData.GetChatGptResponseJson(openAiUrl);
            return response;
        }

        /// <summary>
        /// Get info about a fine-tuning job.
        /// </summary>
        /// <param name="fineTuningJobId">The ID of the fine-tuning job. Required path parameter</param>
        /// <returns>The fine-tuning object with the given ID.</returns>
        /// <see cref="https://platform.openai.com/docs/api-reference/fine-tuning/retrieve"/>
        /// <see cref="https://platform.openai.com/docs/guides/fine-tuning"/>
        /// <see cref="https://platform.openai.com/docs/api-reference/fine-tuning/object"/>
        public async Task<string> RetrieveJson(string fineTuningJobId)
        {
            string url = settings.OpenAiUrlFileTuningJobsRetrieve.ToString().Replace("{fine_tuning_job_id}", fineTuningJobId);
            Uri openAiUrl = new Uri(url);
            string response = await OpenAiData.GetChatGptResponseJson(openAiUrl);
            return response;
        }

        /// <summary>
        /// Immediately cancel a fine-tune job.
        /// </summary>
        /// <param name="fineTuningJobId">The ID of the fine-tuning job to cancel. Required path parameter</param>
        /// <returns>The cancelled fine-tuning object.</returns>
        /// <see cref="https://platform.openai.com/docs/api-reference/fine-tuning/cancel"/>
        /// <see cref="https://platform.openai.com/docs/api-reference/fine-tuning/object"/>
        public async Task<string> CancelJson(string fineTuningJobId)
        {
            string url = settings.OpenAiUrlFileTuningJobsCancel.ToString().Replace("{fine_tuning_job_id}", fineTuningJobId);
            Uri openAiUrl = new Uri(url);
            string response = await OpenAiData.PostChatGptResponseJson(string.Empty, openAiUrl);
            return response;
        }
    }
}
