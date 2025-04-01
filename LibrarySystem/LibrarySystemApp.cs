using LibrarySystem.UserCommunication;

namespace LibrarySystem;

public class LibrarySystemApp(IUserCommunicator userCommunicator)
{
    private readonly IUserCommunicator _userCommunicator = userCommunicator;

    public void Run()
    {
        _userCommunicator.Print(GetMainMenu());
    }

    private string GetMainMenu()
    {
        return """
                [S]earch book
                [A]dd book
                [M]anage customers
                [O]ptions
                
                [E]xit
               """;
    }
}