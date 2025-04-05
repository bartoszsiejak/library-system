using LibrarySystem;
using LibrarySystem.DataStructures;
using LibrarySystem.Menus;
using LibrarySystem.Menus.Options;
using LibrarySystem.Menus.Options.BookOption;
using LibrarySystem.Search;
using LibrarySystem.UserCommunication;
using LibrarySystem.Validation;

var bookStorage = new BookStorage([]);
var customerStorage = new CustomerStorage([]);

var userCommunicator = new ConsoleUserCommunicator(new ConsoleWrapper());
var bookValidator = new BookValidator();
var addBookOption = new AddBookOption(userCommunicator, bookValidator, bookStorage);
var bookSearcherByTitle = new BookSearcherByTitle(userCommunicator, bookValidator);
var bookSearcherByAuthor = new BookSearcherByAuthor(userCommunicator, bookValidator);
var bookSearcherByIsbn = new BookSearcherByIsbn(userCommunicator, bookValidator);
var searchBookMenu = new SearchBookMenu(
    userCommunicator,
    bookSearcherByTitle,
    bookSearcherByAuthor,
    bookSearcherByIsbn);
var bookManagerMenu = new BookManagerMenu(
    userCommunicator,
    new PrintInfoAboutBookOption(userCommunicator),
    new LendBookOption(userCommunicator, new CustomerReader(customerStorage)),
    new ReturnBookOption(userCommunicator),
    new DeleteBookOption(userCommunicator, bookStorage));
var manageBookOption = new ManageBookOption(
    userCommunicator,
    searchBookMenu,
    bookStorage,
    bookManagerMenu,
    new BooksPrinter(userCommunicator));
var mainMenu = new MainMenu(userCommunicator, addBookOption, manageBookOption);

try
{
    new LibrarySystemApp(
            userCommunicator,
            bookValidator,
            mainMenu,
            bookStorage)
        .Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    Console.ReadKey();
}