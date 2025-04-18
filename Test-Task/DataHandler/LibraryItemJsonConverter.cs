using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Test_Task
{
    public class LibraryItemJsonConverter : JsonConverter<LibraryItem>
    {
        public override LibraryItem Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (JsonDocument document = JsonDocument.ParseValue(ref reader))
            {
                JsonElement root = document.RootElement;

                string type = root.GetProperty("Type").GetString();
                switch (type)
                {
                    case "Book":
                        return JsonSerializer.Deserialize<Book>(root.GetRawText(), options);
                    case "Magazine":
                        return JsonSerializer.Deserialize<Magazine>(root.GetRawText(), options);
                    case "DigitalResource":
                        return JsonSerializer.Deserialize<DigitalResource>(root.GetRawText(), options);
                    default:
                        throw new NotSupportedException($"Unknown type: {type}");
                }
            }
        }
        public override void Write(Utf8JsonWriter writer, LibraryItem value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}
