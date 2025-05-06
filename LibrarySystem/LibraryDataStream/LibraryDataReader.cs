using LibrarySystem.File;
using LibrarySystem.JsonParser;
using LibrarySystem.Models;

namespace LibrarySystem.LibraryDataStream;

public class LibraryDataReader(IFile file, IJsonParser parser) : ILibraryDataReader
{
    private readonly IFile _file = file;
    private readonly IJsonParser _parser = parser;
    public LibraryData Read(string path)
    {
        if (!_file.IsExist(path)) return new LibraryData([], []);
        
        var json = _file.Load(path);
        return _parser.Deserialize<LibraryData>(json);
    }
}