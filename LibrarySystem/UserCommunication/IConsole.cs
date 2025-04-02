namespace LibrarySystem.UserCommunication;

public interface IConsole
{
    void WriteLine(string message);
    void Write (string message);
    public string? ReadLine();
    ConsoleKeyInfo ReadKey(bool intercept);
    public void Clear();
}