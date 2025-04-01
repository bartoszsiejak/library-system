namespace LibrarySystem.UserCommunication;

public interface IUserCommunicator
{
    public void Print(string message);
    char GetKey();
}