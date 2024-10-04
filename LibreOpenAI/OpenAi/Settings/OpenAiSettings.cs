using System.Text;

namespace LibreOpenAI.OpenAi.Settings
{
    public class OpenAiSettings : IOpenAiSettings
    {
        public Uri OpenAiUrl { get; set; } = new Uri("https://api.openai.com/v1/chat/completions");
        public Encoding Encoding { get; set; } = Encoding.UTF8;
        public string MediaType { get; set; } = "application/json";
    }
}
