using LibrarySystem;
using LibrarySystem.BookModel;
using LibrarySystem.DataStructures;
using LibrarySystem.Menus;
using LibrarySystem.Menus.Options;
using LibrarySystem.UserCommunication;

 IBookStorage bookStorage = new BookStorage();
 var userCommunicator = new ConsoleUserCommunicator(new ConsoleWrapper());
 var bookValidator = new BookValidator();

try
{
    new LibrarySystemApp(
           userCommunicator,
           bookValidator,
            new MainMenu(
                userCommunicator,
                new AddBookOption(
                    userCommunicator,
                    bookValidator,
                    bookStorage)),
            bookStorage)
        .Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    Console.ReadKey();
}
