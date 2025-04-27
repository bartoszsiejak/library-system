using LibrarySystem.Models.BookModel;

namespace LibrarySystem.Models.CustomerModel;

public class Customer(uint id, string firstName, string lastName)
{
    public uint Id { get; } = id;
    public string FirstName { get; } = firstName;
    public string LastName { get; } = lastName;
    public List<Book> BorrowedBooks { get; } = [];
    public void Borrow(Book book)
    {
        if (BorrowedBooks.Contains(book))
        {
            throw new InvalidOperationException("Book is already borrowed.");
        }
        
        BorrowedBooks.Add(book);

        if (book.Borrower is null)
        {
            book.Lend(this);
        }
    }

    public static void Return(Book book)
    {
        book.Return();
    }

    public override string ToString()
    {
        return $"ID: {Id}, Name: {FirstName}, Surname: {LastName}";
    }
}