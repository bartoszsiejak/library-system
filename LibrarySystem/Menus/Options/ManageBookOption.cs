using LibrarySystem.DataStructures;
using LibrarySystem.Search;
using LibrarySystem.UserCommunication;

namespace LibrarySystem.Menus.Options;

public class ManageBookOption(
    IUserCommunicator userCommunicator,
    ISearchMenu searchBookMenu,
    IBookStorage bookStorage,
    IBookManagerMenu bookManagerMenu,
    IBooksPrinter booksPrinter)
    : IOption
{
    private readonly IUserCommunicator _userCommunicator = userCommunicator;
    private readonly ISearchMenu _searchBookMenu = searchBookMenu;
    private readonly IBookStorage _bookStorage = bookStorage;
    private readonly IBookManagerMenu _bookManagerMenu = bookManagerMenu;
    private readonly IBooksPrinter _booksPrinter = booksPrinter;

    public void Run()
    {
        while (true)
        {
            _searchBookMenu.Render();

            var userOption = _userCommunicator.ReadOptionFromUser();

            if (_searchBookMenu.ShouldIExitMenu(userOption))
            {
                return;
            }

            if (_searchBookMenu.IsValidOption(userOption))
            {
                var resultOfSearching = _searchBookMenu.SearchBy(userOption, _bookStorage);
                var books = resultOfSearching.ToArray();
                _booksPrinter.Print(books);
                
                if (books.Length == 0)
                {
                    return;
                }
                
                var index = _userCommunicator.ReadValidBookIndexFromUser(books.Length);
                var selectedBook = books.ElementAt(index - 1);
                
                _bookManagerMenu.Render();
                
                userOption = _userCommunicator.ReadOptionFromUser();
                
                if (_bookManagerMenu.ShouldIExitMenu(userOption))
                {
                    return;
                }

                if (_bookManagerMenu.IsValidOption(userOption))
                {
                    _bookManagerMenu.Exec(userOption, selectedBook);
                    return;
                }
            }
            else
            {
                _userCommunicator.Print("Invalid option!");
            }
        }
    }
}