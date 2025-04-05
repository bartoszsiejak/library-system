using LibrarySystem.BookModel;

namespace LibrarySystem.DataStructures;

public interface IBookStorage
{
    void Add(Book book);
}