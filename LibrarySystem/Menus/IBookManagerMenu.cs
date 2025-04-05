using LibrarySystem.Models.BookModel;

namespace LibrarySystem.Menus;

public interface IBookManagerMenu : IMenu
{
    public void Exec(char userOption, Book book);
}