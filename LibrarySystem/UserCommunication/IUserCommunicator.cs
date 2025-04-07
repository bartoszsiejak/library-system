namespace LibrarySystem.UserCommunication;

public interface IUserCommunicator
{
    void Print(string message);
    void ClearWindow();
    void WaitForKey();
    char ReadOptionFromUser();
    uint ReadCustomerIdFromUser();
    string ReadValidFromUser(string nameOfStringToRead, Func<string, bool> validator);
    int ReadValidBookIndexFromUser(int numberOfItems);
}