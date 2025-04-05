namespace LibrarySystem.UserCommunication;

public class ConsoleUserCommunicator(
    IConsole consoleWrapper) 
    : IUserCommunicator
{
    private readonly IConsole _consoleWrapper = consoleWrapper;
    
    public char ReadOptionFromUser()
    {
        return _consoleWrapper.ReadKey(true).KeyChar;
    }

    public string ReadStringFromUser()
    {
        return _consoleWrapper.ReadLine() ?? string.Empty;
    }

    public void Print(string message)
    {
        _consoleWrapper.WriteLine(message);
    }

    public void ClearWindow()
    {
        _consoleWrapper.Clear();
    }

    public void WaitForKey()
    {
        _consoleWrapper.WriteLine("Press any key to continue...");
        _consoleWrapper.ReadKey(true);
    }
    
    public string ReadValidFromUser(string nameOfStringToRead, Func<string, bool> validator)
    {
        while (true)
        {
            Print($"Enter the {nameOfStringToRead}: ");
            var stringToRead = ReadStringFromUser();

            if (!validator(stringToRead))
            {
                Print($"Invalid {nameOfStringToRead}!");
            }
            else
            {
                return stringToRead;
            }
        }
    }
}