using LibrarySystem.Models;
using LibrarySystem.Models.BookModel;

namespace LibrarySystem.Menus.Options.BookOption;

public interface IBookOption
{
    public void Run(Book book);
}