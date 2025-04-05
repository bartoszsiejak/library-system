using LibrarySystem.DataStructures;
using LibrarySystem.Models;
using LibrarySystem.Models.BookModel;

namespace LibrarySystem.Search;

public interface IBookSearcher
{
    IEnumerable<Book> Search(IBookStorage bookStorage);
}