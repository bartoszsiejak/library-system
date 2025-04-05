using LibrarySystem.DataStructures;
using LibrarySystem.Models;
using LibrarySystem.Models.BookModel;

namespace LibrarySystem.Menus;

public interface ISearchMenu : IMenu
{
    IEnumerable<Book> SearchBy(char userOption, IBookStorage bookStorage);
}