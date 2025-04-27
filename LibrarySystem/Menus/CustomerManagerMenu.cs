using LibrarySystem.Menus.Options;
using LibrarySystem.UserCommunication;

namespace LibrarySystem.Menus;

public class CustomerManagerMenu(
    IUserCommunicator userCommunicator,
    IOption registerCustomerOption) : IExecutionMenu
{
    private readonly IUserCommunicator _userCommunicator = userCommunicator;

    private readonly Dictionary<char, IOption> _customerMenuOption = new()
    {
        { 'R', registerCustomerOption },
    };

    private const string Menu = """
                                [R]egister customer
                                [D]elete customer
                                [F]ind customer
                                                
                                [B]ack
                                """;

    public void Render()
    {
        _userCommunicator.ClearWindow();
        _userCommunicator.Print(Menu);
    }

    public bool IsValidOption(char userOption)
    {
        return _customerMenuOption.ContainsKey(char.ToUpper(userOption));
    }

    public bool ShouldIExitMenu(char userOption)
    {
        return char.ToUpper(userOption).Equals('B');
    }

    public void Exec(char userOption)
    {
        _customerMenuOption[userOption].Run();
    }
}