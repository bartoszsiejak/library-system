using LibrarySystem.UserCommunication;

namespace LibrarySystem;

public class LibrarySystemApp(IUserCommunicator userCommunicator)
{
    private readonly IUserCommunicator _userCommunicator = userCommunicator;

    public void Run()
    {
        _userCommunicator.Print(GetMainMenu());
        SelectOptionByUser();
    }

    private void SelectOptionByUser()
    {
        while (true)
        {
            var chosenOption = _userCommunicator.GetKey();

            switch (char.ToUpper(chosenOption))
            {
                case 'S':
                    //SearchBook();
                    break;
                case 'A':
                    //AddBook();
                    break;
                case 'M':
                    //ManageCustomers();
                    break;
                case 'E':
                    Exit();
                    break;
            }
        }
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

    private void Exit()
    {
        Environment.Exit(0);
    }
}