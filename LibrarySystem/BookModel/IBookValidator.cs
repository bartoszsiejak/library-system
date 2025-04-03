namespace LibrarySystem.BookModel;

public interface IBookValidator
{
    bool IsValidTitle(string title);
    bool IsValidAuthor(string author);
    bool IsValidIsbn(string isbn);
}