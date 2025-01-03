using LibreOpenAI.Base.Creation;
using Microsoft.Extensions.Options;

namespace LibreOpenAI.OpenAi.BatchesAi
{
    public interface IBatches : ICreationBase
    {
        /// <summary>
        /// Retrieves a batch.
        /// </summary>
        /// <param name="batch_id">The ID of the batch to retrieve. It's a string - Required</param>
        /// <returns>The Batch object matching the specified ID.</returns>
        /// <see cref="https://platform.openai.com/docs/api-reference/batch/retrieve"/>
        /// <seealso cref="https://platform.openai.com/docs/api-reference/batch/object"/>
        Task<string> RetrieveJson(string batchId);
        Task<dynamic> RetrieveDynamic(string batchId);
        /// <summary>
        /// Cancels an in-progress batch. The batch will be in status cancelling for up to 10 minutes, before changing to cancelled, where it will have partial results (if any) available in the output file.
        /// </summary>
        /// <param name="batch_id">The ID of the batch to cancel. It's a string - Required</param>
        /// <returns>The Batch object matching the specified ID.</returns>
        /// <see cref="https://platform.openai.com/docs/api-reference/batch/cancel"/>
        /// <seealso cref="https://platform.openai.com/docs/api-reference/batch/object"/>
        Task<string> CancelJson(string batchId);
        Task<dynamic> CancelDynamic(string batchId);
        /// <summary>
        /// List your organization's batches.
        /// </summary>
        /// <param name="limit">A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20. It's an integer - Optional -         Defaults to 20</param>
        /// <param name="after">A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list. It's a string - Optional</param>
        /// <returns>A list of paginated Batch objects.</returns>
        /// <see cref="https://platform.openai.com/docs/api-reference/batch/list"/>
        /// <seealso cref="https://platform.openai.com/docs/api-reference/batch/object"/>
        Task<string> ListJson(int limit = 20, string after = "");
        Task<dynamic> ListDynamic(int limit = 20, string after = "");
    }
}