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
        string OpenAiApiKey { get; set; }
    }
}