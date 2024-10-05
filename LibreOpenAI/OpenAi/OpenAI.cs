//using LibreOpenAI.Mapper;
using LibreOpenAI.OpenAi.ChatAi;
using LibreOpenAI.OpenAi.ConfigurationAi;
using LibreOpenAI.OpenAi.Settings;

namespace LibreOpenAI.OpenAi
{
    public class OpenAI : IOpenAI
    {
        private readonly IConfiguration configuration;
        private readonly IOpenAiSettings settings;
        //private readonly MappedManager mapper = MappedManager.Instance;

        public OpenAI()
        {
            settings = new OpenAiSettings();
            Chat = new Chat(settings);
            string spiKey = GetSpiKey();
            configuration = new Configuration(spiKey);
        }

        public OpenAI(IConfiguration configuration)
        {
            settings = new OpenAiSettings();
            Chat = new Chat(settings);
            this.configuration = configuration;

            if (configuration != null || string.IsNullOrWhiteSpace(this.configuration.SpiKey))
            {
                this.configuration.SpiKey = GetSpiKey();
            }
        }

        public OpenAI(IConfiguration configuration, IOpenAiSettings settings)
        {
            this.settings = settings ?? new OpenAiSettings();
            Chat = new Chat(this.settings);
            this.configuration = configuration;

            if (configuration != null || string.IsNullOrWhiteSpace(this.configuration.SpiKey))
            {
                this.configuration.SpiKey = GetSpiKey();
            }
        }

        public IChat Chat { get; set; }

        private string GetSpiKey()
        {
            string spiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY") ?? string.Empty;
            return spiKey;
        }
    }
}
