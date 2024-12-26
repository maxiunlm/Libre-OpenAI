using LibreOpenAI.Base.Creation;
using LibreOpenAI.OpenAi.Settings;

namespace LibreOpenAI.OpenAi.FineTuningAi.JobsAi
{
    public class FineTuningJobs : CreationBase
    {
        public FineTuningJobs(IOpenAiSettings settings) : base(settings, settings.OpenAiUrlFileTuningJobs)
        {
        }

        // TODO: Unit Tests !!!!!!!!!!!!!!!!!!!!!!!!
    }
}
