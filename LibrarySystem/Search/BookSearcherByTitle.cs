using LibrarySystem.DataStructures;
using LibrarySystem.Models;
using LibrarySystem.Models.BookModel;
using LibrarySystem.UserCommunication;
using LibrarySystem.Validation;

namespace LibrarySystem.Search;

public class BookSearcherByTitle(
    IUserCommunicator userCommunicator,
    IBookValidator bookValidator)
    : IBookSearcher
{
    private readonly IUserCommunicator _userCommunicator = userCommunicator;
    private readonly IBookValidator _bookValidator = bookValidator;

    public IEnumerable<Book> Search(IBookStorage bookStorage)
    {
        var bookTitle = _userCommunicator.ReadValidFromUser("title", _bookValidator.IsValidTitle);
        return bookStorage.Books.Where(book => book.Title == bookTitle);
    }
}