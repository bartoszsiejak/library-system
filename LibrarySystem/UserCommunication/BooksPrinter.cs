using LibrarySystem.Models;
using LibrarySystem.Models.BookModel;

namespace LibrarySystem.UserCommunication;

public class BooksPrinter(IUserCommunicator userCommunicator) : IBooksPrinter
{
    private readonly IUserCommunicator _userCommunicator = userCommunicator;

    public void Print(IEnumerable<Book> books)
    {
        var items = books.ToArray();
        
        _userCommunicator.ClearWindow();
        
        if (items.Length == 0)
        {
            _userCommunicator.Print("Not found any books!");
            return;
        }

        for (var i = 0; i < items.Length; i++)
        {
            _userCommunicator.Print($"***{i + 1}***" + Environment.NewLine + items[i]);
        }
    }
}