using LibrarySystem.Models.BookModel;
using LibrarySystem.Models.CustomerModel;

namespace LibrarySystem.Models;

public class LibraryData(List<Book> books, Dictionary<uint, Customer> customers)
{
    public List<Book> Books { get;  } = books;
    public Dictionary<uint, Customer> Customers { get;} = customers;
}