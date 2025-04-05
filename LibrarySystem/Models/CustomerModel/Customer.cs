using LibrarySystem.Models.BookModel;

namespace LibrarySystem.Models.CustomerModel;

public class Customer(uint id, string firstName, string lastName)
{
    public uint Id { get; } = id;
    public string FirstName { get; } = firstName;
    public string LastName { get; } = lastName;
    public List<Book> BorrowedBooks { get;}

    public void Borrow(Book book)
    {
        BorrowedBooks.Add(book);
        book.Lend(this);
    }

    public static void Return(Book book)
    {
        book.Return();
    }
}