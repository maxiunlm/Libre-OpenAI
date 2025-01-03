using LibreOpenAI.Base.Creation;

namespace LibreOpenAI.OpenAi.FineTuningAi.JobsAi
{
    public interface IJobs : ICreationBase
    {
        /// <summary>
        /// Immediately cancel a fine-tune job.
        /// </summary>
        /// <param name="fineTuningJobId">The ID of the fine-tuning job to cancel. Required path parameter</param>
        /// <returns>The cancelled fine-tuning object.</returns>
        /// <see cref="https://platform.openai.com/docs/api-reference/fine-tuning/cancel"/>
        /// <seealso cref="https://platform.openai.com/docs/api-reference/fine-tuning/object"/>
        Task<string> CancelJson(string fineTuningJobId);
        Task<dynamic> CancelDynamic(string fineTuningJobId);
        /// <summary>
        /// Get status updates for a fine-tuning job.
        /// </summary>
        /// <param name="fineTuningJobId">Number of fine-tuning jobs to retrieve. Required path parameter.</param>
        /// <param name="limit">Number of events to retrieve. Optional query parameter. Defaults to 20.</param>
        /// <param name="after">Identifier for the last event from the previous pagination request. Optional query parameter.</param>
        /// <returns>A list of fine-tuning event objects.</returns>
        /// <see cref="https://platform.openai.com/docs/api-reference/fine-tuning/list-events"/>
        Task<string> ListEventsJson(string fineTuningJobId, int limit = 20, string after = "");
        Task<dynamic> ListEventsDynamic(string fineTuningJobId, int limit = 20, string after = "");
        /// <summary>
        /// List your organization's fine-tuning jobs.
        /// </summary>
        /// <param name="limit">Number of fine-tuning jobs to retrieve. Optional query parameter. Defaults to 20.</param>
        /// <param name="after">Identifier for the last job from the previous pagination request. Optional query parameter.</param>
        /// <returns>A list of paginated fine-tuning job objects.</returns>
        /// <see cref="https://platform.openai.com/docs/api-reference/fine-tuning/list"/>
        /// <seealso cref="https://platform.openai.com/docs/api-reference/fine-tuning/object"/>
        Task<string> ListJson(int limit = 20, string after = "");
        Task<dynamic> ListDynamic(int limit = 20, string after = "");
        /// <summary>
        /// Get info about a fine-tuning job.
        /// </summary>
        /// <param name="fineTuningJobId">The ID of the fine-tuning job. Required path parameter</param>
        /// <returns>The fine-tuning object with the given ID.</returns>
        /// <see cref="https://platform.openai.com/docs/api-reference/fine-tuning/retrieve"/>
        /// <seealso cref="https://platform.openai.com/docs/guides/fine-tuning"/>
        /// <seealso cref="https://platform.openai.com/docs/api-reference/fine-tuning/object"/>
        Task<string> RetrieveJson(string fineTuningJobId);
        Task<dynamic> RetrieveDynamic(string fineTuningJobId);
    }
}