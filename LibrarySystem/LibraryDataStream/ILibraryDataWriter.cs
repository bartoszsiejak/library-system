using LibrarySystem.Models;

namespace LibrarySystem.LibraryDataStream;

public interface ILibraryDataWriter
{
    void Save(string path, LibraryData libraryData);
}