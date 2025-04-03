using LibrarySystem.BookModel;
using LibrarySystem.UserCommunication;

namespace LibrarySystem;

public class LibrarySystemApp(
    IUserCommunicator userCommunicator,
    IBookValidator bookValidator)
{
    private readonly IUserCommunicator _userCommunicator = userCommunicator;
    private readonly IBookValidator _bookValidator = bookValidator;
    private readonly List<Book> _books = [];

    private const string Menu = """
                                [S]earch book
                                [A]dd book
                                [M]anage customers
                                [O]ptions
                                                
                                [E]xit
                                """;

    public void Run()
    {
        while (true)
        {
            _userCommunicator.Print(Menu);
            var userOption = _userCommunicator.ReadOptionFromUser();
            _userCommunicator.ClearWindow();
            
            switch (char.ToUpper(userOption))
            {
                case 'S':
                    //SearchBook();
                    break;
                case 'A':
                    AddBookToLibrary();
                    break;
                case 'M':
                    //ManageCustomers();
                    break;
                case 'E':
                    return;
                default:
                    _userCommunicator.Print("Invalid option!");
                    break;
            }
            _userCommunicator.WaitForKey();
            _userCommunicator.ClearWindow();
        }
    }

    private void AddBookToLibrary()
    {
        var book = CreateBookFromUser();
        _books.Add(book);
        _userCommunicator.ClearWindow();
        _userCommunicator.Print("Book added: ");
        _userCommunicator.Print(book.ToString());
    }

    private Book CreateBookFromUser()
    {
        var title = ReadValid("title", _bookValidator.IsValidTitle);
        var author = ReadValid("author", _bookValidator.IsValidAuthor);
        var isbn = ReadValid("ISBN", _bookValidator.IsValidIsbn);

        return new Book(title, author, isbn);
    }

    private string ReadValid(string nameOfStringToRead, Func<string, bool> validator)
    {
        while (true)
        {
            _userCommunicator.Print($"Enter the {nameOfStringToRead}: ");
            var stringToRead = _userCommunicator.ReadStringFromUser();
            
            if (!validator(stringToRead))
            {
                _userCommunicator.Print($"Invalid {nameOfStringToRead}!");
            }
            else
            {
                return stringToRead;
            }
        } 
    }
}