using LibrarySystem;
using LibrarySystem.UserCommunication;

try
{
    new LibrarySystemApp(
            new ConsoleUserCommunicator(new ConsoleWrapper()))
        .Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
