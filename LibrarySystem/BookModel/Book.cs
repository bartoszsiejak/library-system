namespace LibrarySystem.BookModel;

public class Book(string title, string author, string isbn)
{
    public string Title { get; } = title;
    public string Author { get; } = author;
    public string Isbn { get; } = isbn;
    public Customer? Borrower { get; private set; }

    public override string ToString()
    {
        return $"""
                Title: {Title}
                Author: {Author}
                ISBN-{Isbn.Length}: {Isbn}

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

public class Customer
{
    public string FirstName { get; }
    public string LastName { get; }
}