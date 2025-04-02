namespace LibrarySystem.UserCommunication;

public class UserCommunicator(IConsole consoleWrapper) : IUserCommunicator
{
    private readonly IConsole _consoleWrapper = consoleWrapper;
    public void Print(string message)
    {
        _consoleWrapper.WriteLine(message);
    }

    public char GetKey()
    {
        return _consoleWrapper.ReadKey(true).KeyChar;
    }

    public string GetValidTittle()
    {
        _consoleWrapper.Clear();
        while(true)
        {
            var tittle = GetStringFromUser("Enter tittle: ");
            if (tittle.Length > 0)
            {
                return tittle;
            }
            
            _consoleWrapper.WriteLine("Tittle must be at least one character!");
        } 
    }

    public string GetValidAuthor()
    {
        _consoleWrapper.Clear();
        while (true)
        {
            var author = GetStringFromUser("Enter an author: ");
            
            if (author == string.Empty)
            {
                return "Unknown author";
            }

            if (author.Length < 3)
            {
                _consoleWrapper.WriteLine("Author must be at least 3 characters!");
            }
            else  if(IsValidAuthor(author))
            {
                return author;
            }
            else
            {
                _consoleWrapper.WriteLine("Invalid author!");
            }
        }
        
    }

    private static readonly char[] SeparatorAuthorName = [' ', '.', '-'];

    private static bool IsValidAuthor(string author)
    {
        return author
            .Split(SeparatorAuthorName)
            .All(item => char.IsUpper(item[0]) && char.IsLetter(item[0]));
    }

    private string GetStringFromUser(string message)
    {
        _consoleWrapper.Write(message);
        return _consoleWrapper.ReadLine() ?? string.Empty;
    }
}