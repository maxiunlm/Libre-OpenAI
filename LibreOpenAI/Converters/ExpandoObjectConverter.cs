using System.Dynamic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LibreOpenAI.Converters
{
    internal class ExpandoObjectConverter : JsonConverter<ExpandoObject>
    {
        public override ExpandoObject Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return ReadObject(ref reader);
        }

        private ExpandoObject ReadObject(ref Utf8JsonReader reader)
        {
            var expando = new ExpandoObject() as IDictionary<string, object>;

            if (reader.TokenType != JsonTokenType.StartObject)
                throw new JsonException("ExpandoObjectConverter.ReadObject: JSON must start with an object.");

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                    return (ExpandoObject)expando;

                if (reader.TokenType != JsonTokenType.PropertyName)
                    throw new JsonException("ExpandoObjectConverter.ReadObject: Expected a property name.");

                string propertyName = reader.GetString()!;
                reader.Read();

                expando[propertyName] = ReadValue(ref reader);
            }

            throw new JsonException("ExpandoObjectConverter.ReadObject: Malformed JSON.");
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

            throw new JsonException("ExpandoObjectConverter.ReadArray: Malformed JSON in an array.");
        }

        public override void Write(Utf8JsonWriter writer, ExpandoObject value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}
