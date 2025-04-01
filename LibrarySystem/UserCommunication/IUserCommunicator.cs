namespace LibrarySystem.UserCommunication;

public interface IUserCommunicator
{
    void Print(string message);
    char GetKey();
}