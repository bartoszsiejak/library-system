using System.Data;
using LibrarySystem.DataStructures;
using LibrarySystem.File;
using LibrarySystem.LibraryDataStream;
using LibrarySystem.Menus;
using LibrarySystem.Models;
using LibrarySystem.UserCommunication;
using LibrarySystem.Validation;

namespace LibrarySystem;

public class LibrarySystemApp(
    IUserCommunicator userCommunicator,
    IBookValidator bookValidator,
    IExecutionMenu mainMenu,
    IBookStorage bookStorage,
    ICustomerStorage customerStorage,
    IFile file,
    ILibraryDataReader dataReader,
    ILibraryDataWriter dataWriter,
    string dataPath
   )
{
    private readonly IUserCommunicator _userCommunicator = userCommunicator;
    private readonly IBookValidator _bookValidator = bookValidator;
    private readonly IExecutionMenu _mainMenu = mainMenu;
    private readonly IBookStorage _booksStorage = bookStorage;
    private readonly ICustomerStorage _customerStorage = customerStorage;
    private readonly IFile _file = file;
    private readonly ILibraryDataReader _dataReader = dataReader;
    private readonly ILibraryDataWriter _dataWriter = dataWriter;
    private readonly string _path = dataPath;

    public void Run()
    {
        if (_file.IsExist(_path))
        {
            LoadLibraryData();
        }
        
        while (true)
        {
            _mainMenu.Render();
            var userOption = _userCommunicator.ReadOptionFromUser();

            if (_mainMenu.ShouldIExitMenu(userOption))
            {
                var libraryData = new LibraryData(bookStorage.Books, customerStorage.Customers);
                _dataWriter.Save(_path, libraryData);
                return;
            }

            if (_mainMenu.IsValidOption(userOption))
            {
                _mainMenu.Exec(userOption);
            }
            else
            {
                _userCommunicator.Print("Invalid option!");
            }

            _userCommunicator.WaitForKey();
        }
    }

    private void LoadLibraryData()
    {
        var libraryData = _dataReader.Read(_path);
        _booksStorage.LoadBooks(libraryData.Books);
        _customerStorage.LoadCustomers(libraryData.Customers);
    }
}