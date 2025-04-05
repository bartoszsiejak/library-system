using LibrarySystem.BookModel;

namespace LibrarySystem.DataStructures;

public class BookStorage : IBookStorage
{
    private readonly List<Book> _books = [];

    public void Add(Book book)
    {
        _books.Add(book);
    }
}