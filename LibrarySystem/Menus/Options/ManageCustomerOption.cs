using LibrarySystem.Search;
using LibrarySystem.UserCommunication;

namespace LibrarySystem.Menus.Options;

public class ManageCustomerOption(
    IUserCommunicator userCommunicator,
    IExecutionMenu customerMenu)
    : IOption
{
    private readonly IExecutionMenu _customerMenu = customerMenu;
    private readonly IUserCommunicator _userCommunicator = userCommunicator;

    public void Run()
    {
        while (true)
        {
            _customerMenu.Render();
            var userOption = _userCommunicator.ReadOptionFromUser();

            if (_customerMenu.ShouldIExitMenu(userOption))
            {
                return;
            }

            if (_customerMenu.IsValidOption(userOption))
            {
                _customerMenu.Exec(char.ToUpper(userOption));
            }
            else
            {
                _userCommunicator.Print("Invalid option!");
            }
        }
    }
}