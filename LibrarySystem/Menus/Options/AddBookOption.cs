using LibrarySystem.DataStructures;
using LibrarySystem.Models;
using LibrarySystem.Models.BookModel;
using LibrarySystem.UserCommunication;
using LibrarySystem.Validation;

namespace LibrarySystem.Menus.Options;

public class AddBookOption(
    IUserCommunicator userCommunicator, 
    IBookValidator bookValidator,
    IBookStorage bookStorage) 
    : IOption
{
    private readonly IUserCommunicator _userCommunicator = userCommunicator;
    private readonly IBookValidator _bookValidator = bookValidator;
    private readonly IBookStorage _bookStorage = bookStorage;

    public void Run()
    {
        var book = CreateBookFromUser();
        _bookStorage.Add(book);
        ShowInfoAboutAddedBook(book);
    }
    
    private Book CreateBookFromUser()
    {
        var title = _userCommunicator.ReadValidFromUser("title", _bookValidator.IsValidTitle);
        var author = _userCommunicator.ReadValidFromUser("author", _bookValidator.IsValidAuthor);
        var isbn = _userCommunicator.ReadValidFromUser("ISBN", _bookValidator.IsValidIsbn);
        
        return new Book(title, author, isbn);
    }
    
    private void ShowInfoAboutAddedBook(Book book)
    {
        _userCommunicator.ClearWindow();
        _userCommunicator.Print("Book added: ");
        _userCommunicator.Print(book.ToString());
    }
}