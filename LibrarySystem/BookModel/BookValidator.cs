namespace LibrarySystem.BookModel;

public class BookValidator : IBookValidator
{
    public bool IsValidTitle(string title)
    {
        return title.Length > 0;
    }
    
    public bool IsValidAuthor(string author)
    {
        var isValidFormat =  author
            .Split(' ', '.', '-')
            .All(item => char.IsUpper(item[0]) && char.IsLetter(item[0]));
        
        var isValidLength = author.Length >= 3;
        
        return isValidFormat && isValidLength;
    }
}