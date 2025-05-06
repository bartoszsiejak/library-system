using LibrarySystem.Models;
using LibrarySystem.Models.BookModel;

namespace LibrarySystem.DataStructures;

public interface IBookStorage
{
    public List<Book> Books { get; }
    void Add(Book book);
    void Remove(Book book);
    void LoadBooks(List<Book> books);
}