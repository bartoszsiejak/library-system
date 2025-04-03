namespace LibrarySystem.UserCommunication;

public interface IUserCommunicator
{
    char ReadOptionFromUser();
    string ReadStringFromUser();
    void Print(string message);
    void ClearWindow();
}