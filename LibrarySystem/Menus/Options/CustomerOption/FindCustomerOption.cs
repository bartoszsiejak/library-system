using LibrarySystem.DataStructures;
using LibrarySystem.UserCommunication;

namespace LibrarySystem.Menus.Options.CustomerOption;

public class FindCustomerOption(IUserCommunicator userCommunicator, ICustomerReader customerReader) : IOption
{
    private readonly IUserCommunicator _userCommunicator = userCommunicator;
    private readonly ICustomerReader _customerReader = customerReader;

    public void Run()
    {
        var customerId = _userCommunicator.ReadCustomerIdFromUser();
        var customer = customerReader.ReadOrDefault(customerId);

        if (customer is null)
        {
            _userCommunicator.Print("Customer not found!");
        }
        else
        {
            _userCommunicator.Print(customer.ToString());
            if (customer.BorrowedBooks.Count > 0)
            {
                _userCommunicator.Print("Borrowed books:");
                var books = customer.BorrowedBooks.Select(book => book.ToString());
                _userCommunicator.Print(string.Join(Environment.NewLine, books));
            }
            else
            {
                _userCommunicator.Print("No books borrowed!");
            }
        }
    }
}