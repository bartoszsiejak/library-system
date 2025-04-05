using LibrarySystem.Models.CustomerModel;

namespace LibrarySystem.Models.BookModel;

public class Book(string title, string author, string isbn)
{
    public string Title { get; } = title;
    public string Author { get; } = author;
    public string Isbn { get; } = isbn;
    public Customer? Borrower { get; private set; }

    public void Lend(Customer customer)
    {
        Borrower = customer;
        customer.Borrow(this);
    }

    public void Return()
    {
        if (Borrower is null)
        {
            throw new NullReferenceException("Cannot return null borrower");
        }
        
        Borrower.BorrowedBooks.Remove(this);
        Borrower = null;
    }

    public override string ToString()
    {
        return $"""
                Title: {Title}
                Author: {Author}
                ISBN: {Isbn}

                """;
    }

    public override bool Equals(object? obj)
    {
        return obj is Book item && Equals(item);
    }

    private bool Equals(Book other)
    {
        return Isbn == other.Isbn;
    }

    public override int GetHashCode()
    {
        return Isbn.GetHashCode();
    }
}