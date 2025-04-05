using LibrarySystem.Models;
using LibrarySystem.Models.BookModel;

namespace LibrarySystem.DataStructures;

public class BookStorage(List<Book> books) : IBookStorage
{
    public List<Book> Books { get; } = books;

    public void Add(Book book)
    {
        Books.Add(book);
    }

    public void Remove(Book book)
    {
        Books.Remove(book);
    }
}