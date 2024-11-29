using LibreOpenAIExtensions.OpenAi.CurlAi;

namespace LibreOpenAI.OpenAi
{
    public class OpenAiExtension: OpenAI // TODO: Unit Testing
    {
        public OpenAiExtension() 
        { 
            Curl = new Curl();
        }

        public ICurl Curl { get; set; }
    }
}
