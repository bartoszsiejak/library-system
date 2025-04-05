namespace LibrarySystem.Menus;

public interface IMenu
{
    void Render();

    bool IsValidOption(char userOption);
    void Exec(char userOption);
}