using System.Text.Json;
using System.Text.Json.Serialization;

namespace LibreOpenAI.Converters
{
    internal class DictionaryConverter : JsonConverter<IDictionary<string, object>>
    {
        public override IDictionary<string, object> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return ReadObject(ref reader);
        }

        private IDictionary<string, object> ReadObject(ref Utf8JsonReader reader)
        {
            var dictionary = new Dictionary<string, object>();

            if (reader.TokenType != JsonTokenType.StartObject)
                throw new JsonException("DictionaryConverter.ReadObject: JSON must start with an object.");

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                    return dictionary;

                if (reader.TokenType != JsonTokenType.PropertyName)
                    throw new JsonException("DictionaryConverter.ReadObject: Expected a property name.");

                string propertyName = reader.GetString()!;
                reader.Read();

                dictionary[propertyName] = ReadValue(ref reader);
            }

            throw new JsonException("DictionaryConverter.ReadObject: Malformed JSON.");
        }

        private object ReadValue(ref Utf8JsonReader reader)
        {
            return reader.TokenType switch
            {
                JsonTokenType.String => reader.GetString(),
                JsonTokenType.Number => reader.TryGetInt64(out long l) ? l : reader.GetDouble(),
                JsonTokenType.True => true,
                JsonTokenType.False => false,
                JsonTokenType.StartObject => ReadObject(ref reader),
                JsonTokenType.StartArray => ReadArray(ref reader),
                _ => null
            };
        }

        private List<object> ReadArray(ref Utf8JsonReader reader)
        {
            var list = new List<object>();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndArray)
                    return list;

                list.Add(ReadValue(ref reader));
            }

            throw new JsonException("DictionaryConverter.ReadArray: Malformed JSON in an array.");
        }

        public override void Write(Utf8JsonWriter writer, IDictionary<string, object> value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}
