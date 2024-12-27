using LibreOpenAI.Base.Creation;

namespace LibreOpenAI.OpenAi.FineTuningAi.JobsAi
{
    public interface IJobs : ICreationBase
    {
        Task<string> CancelJson(string fineTuningJobId);
        Task<string> ListEventsJson(string fineTuningJobId, int limit = 20, string after = "");
        Task<string> ListJson(int limit = 20, string after = "");
        Task<string> RetrieveJson(string fineTuningJobId);
    }
}