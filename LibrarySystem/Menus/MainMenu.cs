using LibrarySystem.Menus.Options;
using LibrarySystem.UserCommunication;

namespace LibrarySystem.Menus;

public class MainMenu(IUserCommunicator userCommunicator, IOption addBookOption) : IMenu
{
    private readonly IUserCommunicator _userCommunicator = userCommunicator;
    private readonly Dictionary<char, IOption> _menuOptions = new()
    {
        { 'A', addBookOption },
    };

    private const string Menu = """
                                Manage [b]ook
                                [A]dd book
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

    public void Exec(char userOption)
    {
        _menuOptions[char.ToUpper(userOption)].Run();
    }
}