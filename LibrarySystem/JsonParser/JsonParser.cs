using System.Text.Json;

namespace LibrarySystem.JsonParser;

public class JsonParser : IJsonParser
{
    public string Serialize<T>(T objectToSerialize)
    {
        return JsonSerializer.Serialize(objectToSerialize);
    }

    public T Deserialize<T>(string json)
    {
        return JsonSerializer.Deserialize<T>(json) ??
               throw new NullReferenceException("Json could not be deserialized!");
    }
}