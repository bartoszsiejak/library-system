using LibrarySystem;
using LibrarySystem.UserCommunication;

try
{
    new LibrarySystemApp(
            new UserCommunicator())
        .Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
