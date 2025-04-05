using LibrarySystem.Models;
using LibrarySystem.Models.BookModel;
using LibrarySystem.UserCommunication;

namespace LibrarySystem.Menus.Options.BookOption;

public class PrintInfoAboutBookOption(
    IUserCommunicator userCommunicator) : IBookOption
{
    private readonly IUserCommunicator _userCommunicator = userCommunicator;


    public void Run(Book book)
    {
        _userCommunicator.Print(book.ToString());
    }
}