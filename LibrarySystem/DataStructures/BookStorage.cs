using LibrarySystem.Models;
using LibrarySystem.Models.BookModel;

namespace LibrarySystem.DataStructures;

public class BookStorage : IBookStorage
{
    public List<Book> Books { get; private set; } = [];

    public void Add(Book book)
    {
        Books.Add(book);
    }

    public void Remove(Book book)
    {
        Books.Remove(book);
    }
    public void LoadBooks(List<Book> books)
    {
        Books = books;
    }
}