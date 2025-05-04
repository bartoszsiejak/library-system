namespace LibrarySystem.JsonParser;

public interface IJsonParser
{
    string Serialize<T>(T objectToSerialize);
    T Deserialize<T>(string json);
}