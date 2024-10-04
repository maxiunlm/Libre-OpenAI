using LibreOpenAI.OpenAi.ChatAi.CompletionsAi.Response.Choices;
using Newtonsoft.Json;

namespace LibreOpenAI.Json.Converters
{
    internal class ChoiceResponseConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IChoiceResponse) || objectType == typeof(List<IChoiceResponse>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartArray)
            {
                // Deserialize the array into a list of ChoiceResponse
                var choices = new List<IChoiceResponse>();
                while (reader.Read() && reader.TokenType != JsonToken.EndArray)
                {
                    var choiceResponse = new ChoiceResponse();
                    serializer.Populate(reader, choiceResponse);
                    choices.Add(choiceResponse);
                }
                return choices;
            }

            // Handle single ChoiceResponse (this shouldn't be the case for the choices array)
            var singleChoice = new ChoiceResponse();
            serializer.Populate(reader, singleChoice);
            return singleChoice;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}