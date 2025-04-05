namespace LibrarySystem.UserCommunication;

public interface IUserCommunicator
{
    char ReadOptionFromUser();
    string ReadStringFromUser();
    uint ReadCustomerIdFromUser();
    void Print(string message);
    void ClearWindow();
    void WaitForKey();
    string ReadValidFromUser(string nameOfStringToRead, Func<string, bool> validator);
    int ReadValidBookIndexFromUser(int numberOfItems);
}