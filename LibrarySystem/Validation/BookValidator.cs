namespace LibrarySystem.Validation;

public partial class BookValidator : IBookValidator
{
    public bool IsValidTitle(string title)
    {
        return title.Length > 0;
    }

    public bool IsValidAuthor(string author)
    {
        var isValidFormat = author
            .Split(' ', '.', '-')
            .All(item => char.IsUpper(item[0]) && char.IsLetter(item[0]));

        var isValidLength = author.Length >= 3;

        return isValidFormat && isValidLength;
    }

    public bool IsValidIsbn(string isbn)
    {
        return IsbnValidatorRegex().Match(isbn).Success;
    }

    [System.Text.RegularExpressions.GeneratedRegex(@"^(?=(?:\D*\d){10}(?:(?:\D*\d){3})?$)[\d-]+$")]
    private static partial System.Text.RegularExpressions.Regex IsbnValidatorRegex();
}