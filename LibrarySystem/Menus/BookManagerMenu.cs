using LibrarySystem.Menus.Options;
using LibrarySystem.Menus.Options.BookOption;
using LibrarySystem.Models.BookModel;
using LibrarySystem.UserCommunication;

namespace LibrarySystem.Menus;

public class BookManagerMenu(
    IUserCommunicator userCommunicator, 
    IBookOption printBookInfo,
    IBookOption lendBook,
    IBookOption returnBook,
    IBookOption deleteBook)
    : IBookManagerMenu
{
    private readonly IUserCommunicator _userCommunicator = userCommunicator;
    private readonly Dictionary<char, IBookOption> _menuOptions = new()
    {
        {'P', printBookInfo},
        {'L', lendBook},
        {'R', returnBook},
        {'D', deleteBook}
    };
    
    private const string Menu = """
                                [P]rint book information
                                [L]end a book
                                [R]eturn a book
                                [D]elete book from library
                                                
                                [B]ack
                                """;

    public void Render()
    {
        _userCommunicator.ClearWindow();
        _userCommunicator.Print(Menu);
    }

    public bool IsValidOption(char userOption)
    {
        return _menuOptions.ContainsKey(char.ToUpper(userOption));
    }

    public bool ShouldIExitMenu(char userOption)
    {
        return char.ToUpper(userOption).Equals('B');
    }

    public void Exec(char userOption, Book book)
    {
        _menuOptions[char.ToUpper(userOption)].Run(book);
    }
}