using LibrarySystem.DataStructures;
using LibrarySystem.Menus.Options.BookOption;
using LibrarySystem.Models.BookModel;
using LibrarySystem.UserCommunication;

namespace LibrarySystem.Menus.Options;

public class LendBookOption(IUserCommunicator userCommunicator, ICustomerReader customerReader) : IBookOption
{
    private readonly IUserCommunicator _userCommunicator = userCommunicator;
    private readonly ICustomerReader _customerReader = customerReader;

    public void Run(Book book)
    {
        var customerId = _userCommunicator.ReadCustomerIdFromUser();
        var borrower = _customerReader.ReadOrDefault(customerId);

        if (borrower is null)
        {
            _userCommunicator.Print("Customer not found!");
            return;
        }
        
        book.Lend(borrower);
        _userCommunicator.Print("Book lent!");
    }
}