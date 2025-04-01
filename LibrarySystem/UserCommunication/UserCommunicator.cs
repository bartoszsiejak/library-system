namespace LibrarySystem.UserCommunication;

public class UserCommunicator : IUserCommunicator
{
    public void Print(string message)
    {
        Console.WriteLine(message);
    }

    public char GetKey()
    {
        return Console.ReadKey(true).KeyChar;
    }
}