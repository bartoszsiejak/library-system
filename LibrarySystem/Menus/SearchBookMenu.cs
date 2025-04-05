using LibrarySystem.DataStructures;
using LibrarySystem.Menus.Options;
using LibrarySystem.Models;
using LibrarySystem.Models.BookModel;
using LibrarySystem.Search;
using LibrarySystem.UserCommunication;

namespace LibrarySystem.Menus;

public class SearchBookMenu(
    IUserCommunicator userCommunicator,
    IBookSearcher searchByTitle,
    IBookSearcher searchByAuthor,
    IBookSearcher searchByIsbn)
    : ISearchMenu
{
    private readonly IUserCommunicator _userCommunicator = userCommunicator;

    private readonly Dictionary<char, IBookSearcher> _searchMenuOption = new()
    {
        { 'T', searchByTitle },
        { 'A', searchByAuthor },
        { 'I', searchByIsbn },
    };

    private const string Menu = """
                                [T]itle
                                [A]uthor
                                [I]SBN
                                                
                                [B]ack
                                """;

    public void Render()
    {
        _userCommunicator.ClearWindow();
        _userCommunicator.Print(Menu);
    }

    public bool IsValidOption(char userOption)
    {
        return _searchMenuOption.ContainsKey(char.ToUpper(userOption));
    }

    public IEnumerable<Book> SearchBy(char userOption, IBookStorage bookStorage)
    {
        return _searchMenuOption[char.ToUpper(userOption)].Search(bookStorage);
    }

    public bool ShouldIExitMenu(char userOption)
    {
        return char.ToUpper(userOption).Equals('B');
    }

}