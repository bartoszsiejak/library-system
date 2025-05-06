using LibrarySystem.File;
using LibrarySystem.JsonParser;
using LibrarySystem.Models;

namespace LibrarySystem.LibraryDataStream;

public class LibraryDataWriter(IFile file, IJsonParser parser) : ILibraryDataWriter
{
    private readonly IFile _file = file;
    private readonly IJsonParser _parser = parser;
    public void Save(string path, LibraryData libraryData)
    { 
        var dataAsJson =  _parser.Serialize(libraryData);
        _file.Save(path, dataAsJson);
    }
}