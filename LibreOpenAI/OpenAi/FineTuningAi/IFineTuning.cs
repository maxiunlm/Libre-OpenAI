using LibreOpenAI.Base.Creation;
using LibreOpenAI.OpenAi.FineTuningAi.JobsAi;

namespace LibreOpenAI.OpenAi.FineTuningAi
{
    public interface IFineTuning
    {
        IJobs Jobs { get; set; }
    }
}