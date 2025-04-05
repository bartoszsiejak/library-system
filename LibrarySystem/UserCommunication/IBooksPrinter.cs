using LibrarySystem.Models;
using LibrarySystem.Models.BookModel;

namespace LibrarySystem.UserCommunication;

public interface IBooksPrinter
{
    void Print(IEnumerable<Book> items);
}