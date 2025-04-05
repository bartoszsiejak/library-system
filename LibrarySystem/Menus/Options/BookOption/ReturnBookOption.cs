using LibrarySystem.Models.BookModel;
using LibrarySystem.UserCommunication;

namespace LibrarySystem.Menus.Options.BookOption;

public class ReturnBookOption(IUserCommunicator userCommunicator) : IBookOption
{
    private readonly IUserCommunicator _userCommunicator = userCommunicator;

    public void Run(Book book)
    {
        if (book.Borrower is null)
        {
            _userCommunicator.Print("Book is not borrowed!");
        }
        else
        {
            book.Return();
            _userCommunicator.Print("Returned book!");
        }
    }
}