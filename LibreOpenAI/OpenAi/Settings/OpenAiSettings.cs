﻿using System.Text;

namespace LibreOpenAI.OpenAi.Settings
{
    public class OpenAiSettings : IOpenAiSettings
    {
        public Uri OpenAiUrlCompletions { get; set; } = new Uri("https://api.openai.com/v1/chat/completions");
        public Uri OpenAiUrlEmbeddings { get; set; } = new Uri("https://api.openai.com/v1/embeddings");
        public Uri OpenAiUrlFileTuningJobs { get; set; } = new Uri("https://api.openai.com/v1/fine_tuning/jobs");
        public Uri OpenAiUrlFileTuningJobsCancel { get; set; } = new Uri("https://api.openai.com/v1/fine_tuning/jobs/{fine_tuning_job_id}/cancel");
        public Uri OpenAiUrlFileTuningJobsRetrieve { get; set; } = new Uri("https://api.openai.com/v1/fine_tuning/jobs/{fine_tuning_job_id}");
        public Uri OpenAiUrlFileTuningEvents { get; set; } = new Uri("https://api.openai.com/v1/fine_tuning/jobs/{fine_tuning_job_id}/events");
        public Uri OpenAiUrlBatches { get; set; } = new Uri("https://api.openai.com/v1/batches");
        public Uri OpenAiUrlBatchesRetrieve { get; set; } = new Uri("https://api.openai.com/v1/batches/{batch_id}");
        public Uri OpenAiUrlBatchesCancel { get; set; } = new Uri("https://api.openai.com/v1/batches/{batch_id}/cancel");
        // TODO: CURL: public Uri OpenAiUrlFileTuningCheckpoints { get; set; } = new Uri("https://api.openai.com/v1/fine_tuning/jobs/{fine_tuning_job_id}/checkpoints");

        public Encoding Encoding { get; set; } = Encoding.UTF8;
        public string MediaType { get; set; } = "application/json";
        public string OpenAiApiKey { get; set; } = string.Empty;

        public OpenAiSettings()
        {
            OpenAiApiKey = GetSpiKey(string.Empty);
        }

        public OpenAiSettings(string openAiApiKey)
        {
            OpenAiApiKey = GetSpiKey(openAiApiKey);
        }

        private string GetSpiKey(string openAiApiKey)
        {
            if(string.IsNullOrEmpty(openAiApiKey))
            {
                openAiApiKey = Environment.GetEnvironmentVariable("LIBRE_OPEN_AI_API_KEY") ?? Environment.GetEnvironmentVariable("OPENAI_API_KEY") ?? string.Empty;
            }
            
            return openAiApiKey;
        }
    }
}
