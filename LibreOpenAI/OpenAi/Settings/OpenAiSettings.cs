using System.Text;

namespace LibreOpenAI.OpenAi.Settings
{
    public class OpenAiSettings : IOpenAiSettings
    {
        public Uri OpenAiUrl { get; set; } = new Uri("https://api.openai.com/v1/chat/completions");
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
            openAiApiKey = (string.IsNullOrWhiteSpace(openAiApiKey) ? Environment.GetEnvironmentVariable("OPENAI_API_KEY"): openAiApiKey) ?? string.Empty;

            return openAiApiKey;
        }
    }
}
