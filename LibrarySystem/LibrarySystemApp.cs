using LibrarySystem.BookModel;
using LibrarySystem.DataStructures;
using LibrarySystem.Menus;
using LibrarySystem.UserCommunication;

namespace LibrarySystem;

public class LibrarySystemApp(
    IUserCommunicator userCommunicator,
    IBookValidator bookValidator,
    IMenu mainMenu,
    IBookStorage bookStorage)
{
    private readonly IUserCommunicator _userCommunicator = userCommunicator;
    private readonly IBookValidator _bookValidator = bookValidator;
    private readonly IMenu _mainMenu = mainMenu;
    private readonly IBookStorage _booksStorage = bookStorage;


    public void Run()
    {
        while (true)
        {
            _mainMenu.Render();
            var userOption = _userCommunicator.ReadOptionFromUser();

            if (_mainMenu.IsValidOption(userOption))
            {
                _mainMenu.Exec(userOption);
            }
            else
            {
                _userCommunicator.Print("Invalid option!");
            }

            _userCommunicator.WaitForKey();
        }
    }
}