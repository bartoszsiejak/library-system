using LibrarySystem;
using LibrarySystem.UserCommunication;

try
{
    new LibrarySystemApp(
            new UserCommunicator(new ConsoleWrapper()))
        .Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
