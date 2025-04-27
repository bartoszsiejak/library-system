using LibrarySystem.Menus.Options;
using LibrarySystem.Search;
using LibrarySystem.UserCommunication;

namespace LibrarySystem.Menus;

public class MainMenu(
                        IUserCommunicator userCommunicator,
                        IOption addBookOption,
                        IOption manageBookOption,
                        IOption manageCustomerOption) 
                        : IExecutionMenu
{
    private readonly IUserCommunicator _userCommunicator = userCommunicator;
    private readonly Dictionary<char, IOption> _menuOptions = new()
    {
        { 'A', addBookOption },
        { 'B', manageBookOption },
        { 'M', manageCustomerOption }
    };

    private const string Menu = """
                                [B]ook manager
                                [A]dd a book
                                [M]anage customers
                                [O]ptions
                                                
                                [E]xit
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
        return char.ToUpper(userOption).Equals('E');
    }

    public void Exec(char userOption)
    {
        _menuOptions[char.ToUpper(userOption)].Run();
    }
}