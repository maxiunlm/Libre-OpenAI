using Newtonsoft.Json;

namespace LibreOpenAI.Exceptions.OpenAI
{
    public class LibreOpenAiJsonReaderException : JsonReaderException
    {
        public LibreOpenAiJsonReaderException(JsonReaderException inner)
            : base("JSON reading error: The JSON response format is unexpected. Check the API response.", inner)
        { }
    }
}