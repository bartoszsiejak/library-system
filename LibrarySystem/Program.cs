using System.Text.Json.Serialization;
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
using LibrarySystem.Models.BookModel;
using LibrarySystem.Models.CustomerModel;
using LibrarySystem.Search;
using LibrarySystem.UserCommunication;
using LibrarySystem.Validation;

var file = new FileWrapper();
var jsonParser = new JsonParser();
var dataReader = new LibraryDataReader(file, jsonParser);
var dataWriter = new LibraryDataWriter(file, jsonParser);
const string Path = "data.json";

var libraryData = dataReader.Read(Path);
var bookStorage = new BookStorage(libraryData.Books);
var customerStorage = new CustomerStorage(libraryData.Customers);

var id = libraryData.Customers.Keys.Any() ? libraryData.Customers.Keys.Max() + 1 : 0u;
var idGenerator = new IdGenerator(id);

var customerReader = new CustomerReader(customerStorage);

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

var registerCustomerOption = new RegisterCustomerOption(userCommunicator, idGenerator, customerStorage);
var deleteCustomerOption = new DeleteCustomerOption(userCommunicator, customerReader, customerStorage);
var findCustomerOption = new FindCustomerOption(userCommunicator, customerReader);
var customerManagerMenu = new CustomerManagerMenu(
    userCommunicator, 
    registerCustomerOption,
    deleteCustomerOption,
    findCustomerOption);
var manageCustomerOption = new ManageCustomerOption(userCommunicator, customerManagerMenu);

var mainMenu = new MainMenu(userCommunicator, addBookOption, manageBookOption, manageCustomerOption);

try
{
    new LibrarySystemApp(
            userCommunicator,
            bookValidator,
            mainMenu,
            bookStorage)
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