using LibreOpenAI.OpenAi.FineTuningAi.JobsAi;
using LibreOpenAI.OpenAi.Settings;
using Newtonsoft.Json;

namespace LibreOpenAI.OpenAi.FineTuningAi
{
    public class FineTuning: IFineTuning
    {
        public FineTuning(IOpenAiSettings settings)
        {
            Jobs = new Jobs(settings);
        }

        /// <summary>
        /// Manage fine-tuning jobs to tailor a model to your specific training data. Related guide: Fine-tune models
        /// </summary>
        [JsonProperty("jobs")]
        public IJobs Jobs { get; set; }
    }
}
