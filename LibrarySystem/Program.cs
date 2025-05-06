using LibrarySystem;
using LibrarySystem.DataGeneration;
using LibrarySystem.DataStructures;
using LibrarySystem.File;
using LibrarySystem.JsonParser;
using LibrarySystem.LibraryDataStream;
using LibrarySystem.Menus;
using LibrarySystem.Menus.Options;
using LibrarySystem.Menus.Options.BookOption;
using LibrarySystem.Menus.Options.CustomerOption;
using LibrarySystem.Models;
using LibrarySystem.Search;
using LibrarySystem.UserCommunication;
using LibrarySystem.Validation;





var bookStorage = new BookStorage();
var customerStorage = new CustomerStorage();
var customerIdGenerator = new CustomerIdGenerator(customerStorage);
var customerReader = new CustomerReader(customerStorage);
var file = new FileWrapper();
var jsonParser = new JsonParser();
var dataReader = new LibraryDataReader(file, jsonParser);
var dataWriter = new LibraryDataWriter(file, jsonParser);

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

var registerCustomerOption = new RegisterCustomerOption(userCommunicator, customerIdGenerator, customerStorage);
var deleteCustomerOption = new DeleteCustomerOption(userCommunicator, customerReader, customerStorage);
var findCustomerOption = new FindCustomerOption(userCommunicator, customerReader);
var customerManagerMenu = new CustomerManagerMenu(
    userCommunicator, 
    registerCustomerOption,
    deleteCustomerOption,
    findCustomerOption);
var manageCustomerOption = new ManageCustomerOption(userCommunicator, customerManagerMenu);

var mainMenu = new MainMenu(userCommunicator, addBookOption, manageBookOption, manageCustomerOption);

const string Path = "data.json";
try
{
    new LibrarySystemApp(
            userCommunicator,
            bookValidator,
            mainMenu,
            bookStorage,
            customerStorage,
            file,
            dataReader,
            dataWriter,
            Path)
        .Run();
    
    dataWriter.Save(
        Path,
        new LibraryData(bookStorage.Books, customerStorage.Customers));
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    Console.ReadKey();
}