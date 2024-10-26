using Newtonsoft.Json;

namespace LibreOpenAI.Exceptions.OpenAI
{
    internal class LibreOpenAiJsonSerializationException : JsonSerializationException
    {
        public LibreOpenAiJsonSerializationException(JsonSerializationException inner)
            : base("Deserialization error: The API response does not match the expected structure. Check for possible changes in the API response format.", 
                  inner)
        { }
    }
}