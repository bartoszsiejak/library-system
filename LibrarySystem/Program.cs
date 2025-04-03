using LibrarySystem;
using LibrarySystem.BookModel;
using LibrarySystem.UserCommunication;

try
{
    new LibrarySystemApp(
            new ConsoleUserCommunicator(
                new ConsoleWrapper()),
            new BookValidator())
        .Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
