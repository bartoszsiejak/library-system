using LibrarySystem.DataStructures;
using LibrarySystem.Menus;
using LibrarySystem.UserCommunication;
using LibrarySystem.Validation;

namespace LibrarySystem;

public class LibrarySystemApp(
    IUserCommunicator userCommunicator,
    IBookValidator bookValidator,
    IExecutionMenu mainMenu,
    IBookStorage bookStorage)
{
    private readonly IUserCommunicator _userCommunicator = userCommunicator;
    private readonly IBookValidator _bookValidator = bookValidator;
    private readonly IExecutionMenu _mainMenu = mainMenu;
    private readonly IBookStorage _booksStorage = bookStorage;


    public void Run()
    {
        while (true)
        {
            _mainMenu.Render();
            var userOption = _userCommunicator.ReadOptionFromUser();

            if (_mainMenu.ShouldIExitMenu(userOption))
            {
                return;
            }

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