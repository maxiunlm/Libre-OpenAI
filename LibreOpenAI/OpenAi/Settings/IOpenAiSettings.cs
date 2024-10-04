using System.Text;

namespace LibreOpenAI.OpenAi.Settings
{
    public interface IOpenAiSettings
    {
        Encoding Encoding { get; set; }
        string MediaType { get; set; }
        Uri OpenAiUrl { get; set; }
    }
}