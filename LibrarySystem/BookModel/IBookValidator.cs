namespace LibrarySystem.BookModel;

public interface IBookValidator
{
    public bool IsValidTitle(string title);
    public bool IsValidAuthor(string author);
}