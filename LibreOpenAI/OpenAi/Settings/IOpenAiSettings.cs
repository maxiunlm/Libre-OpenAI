using System.Text;

namespace LibreOpenAI.OpenAi.Settings
{
    public interface IOpenAiSettings
    {
        Encoding Encoding { get; set; }
        string MediaType { get; set; }
        Uri OpenAiUrlCompletions { get; set; }
        Uri OpenAiUrlEmbeddings { get; set; }
        Uri OpenAiUrlFileTuningJobs { get; set; }
        Uri OpenAiUrlFileTuningJobsCancel { get; set; }
        Uri OpenAiUrlFileTuningJobsRetrieve { get; set; }
        Uri OpenAiUrlFileTuningEvents { get; set; }
        Uri OpenAiUrlBatches { get; set; }
        Uri OpenAiUrlBatchesRetrieve { get; set; }
        Uri OpenAiUrlBatchesCancel { get; set; }
        // TODO: CURL: Extensions: Uri OpenAiUrlFileTuningCheckpoints { get; set; }
        string OpenAiApiKey { get; set; }
    }
}