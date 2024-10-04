namespace LibreOpenAI.OpenAi.ConfigurationAi
{
    public class Configuration : IConfiguration
    {
        public Configuration()
        {
        }

        public Configuration(string spiKey)
        {
            SpiKey = spiKey;
        }

        public string SpiKey { get; set; } = string.Empty;
    }
}
