using LibrarySystem.Search;

namespace LibrarySystem.Menus;

public interface IMenu
{
    void Render();
    bool IsValidOption(char userOption);
    bool ShouldIExitMenu(char userOption);
}