using LibrarySystem.DataStructures;
using LibrarySystem.Models.BookModel;
using LibrarySystem.UserCommunication;

namespace LibrarySystem.Menus.Options.BookOption;

public class DeleteBookOption(IUserCommunicator userCommunicator, IBookStorage bookStorage) : IBookOption
{
    private readonly IUserCommunicator _userCommunicator = userCommunicator;
    private readonly IBookStorage _bookStorage = bookStorage;
    public void Run(Book book)
    {
        if (book.Borrower is not null)
        {
            book.Return();
        }

        _bookStorage.Remove(book);
        _userCommunicator.Print("Book deleted!");
    }
}