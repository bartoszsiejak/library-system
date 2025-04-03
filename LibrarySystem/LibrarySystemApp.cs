using LibrarySystem.BookModel;
using LibrarySystem.UserCommunication;

namespace LibrarySystem;

public class LibrarySystemApp(
    IUserCommunicator userCommunicator,
    IBookValidator bookValidator)
{
    private readonly IUserCommunicator _userCommunicator = userCommunicator;
    private readonly IBookValidator _bookValidator = bookValidator;
    public List<Book> Books { get; private set; } = [];

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

            switch (char.ToUpper(userOption))
            {
                case 'S':
                    //SearchBook();
                    break;
                case 'A':
                    var book = CreateBookFromUser();
                    Books.Add(book);
                    break;
                case 'M':
                    //ManageCustomers();
                    break;
                case 'E':
                    return;
                default:
                    _userCommunicator.Print("Invalid option");
                    break;
            }

            _userCommunicator.ClearWindow();
        }
    }

    private Book CreateBookFromUser()
    {
        var title = ReadValid("title", _bookValidator.IsValidTitle);
        var author = ReadValid("author", _bookValidator.IsValidAuthor);

        return new Book();
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