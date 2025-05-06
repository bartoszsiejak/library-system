using LibrarySystem.Models;

namespace LibrarySystem.LibraryDataStream;

public interface ILibraryDataReader
{
    LibraryData Read(string path);
}