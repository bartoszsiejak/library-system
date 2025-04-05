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

    public uint ReadCustomerIdFromUser()
    {
        while (true)
        {
            _consoleWrapper.Write("Enter Customer ID: ");
            var id = _consoleWrapper.ReadLine();
            var isParsable = uint.TryParse(id, out var customerId);

            if (isParsable)
            {
                return customerId;
            }
            _consoleWrapper.WriteLine("Customer ID must be a number!");
        }
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

    public int ReadValidBookIndexFromUser(int numberOfItems)
    {
        while (true)
        {
            _consoleWrapper.Write("Index of book: ");
            var userOption =_consoleWrapper.ReadLine();
            var canIParse = int.TryParse(userOption, out var indexOfBook);
            
            if (!canIParse)
            {
                _consoleWrapper.WriteLine("Index must be an integer!");
            }
            else if (indexOfBook > numberOfItems || indexOfBook < 1)
            {
                _consoleWrapper.WriteLine("Book index is out of range!");
            }
            else
            {
                return indexOfBook;
            }
        } 
    }
}