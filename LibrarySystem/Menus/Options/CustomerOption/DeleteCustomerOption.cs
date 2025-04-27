using LibrarySystem.DataStructures;
using LibrarySystem.UserCommunication;

namespace LibrarySystem.Menus.Options.CustomerOption;

public class DeleteCustomerOption(
    IUserCommunicator userCommunicator, 
    ICustomerReader customerReader, 
    ICustomerStorage customerStorage) 
    : IOption
{
    private readonly IUserCommunicator _userCommunicator = userCommunicator;
    private readonly ICustomerReader _customerReader = customerReader;
    private readonly ICustomerStorage _customerStorage = customerStorage;

    public void Run()
    {
        _userCommunicator.ClearWindow();
        var customerId = _userCommunicator.ReadCustomerIdFromUser();
        var customer = _customerReader.ReadOrDefault(customerId);
        
        if (customer is null)
        {
            _userCommunicator.Print("Customer not found!");
        }
        else
        {
                _userCommunicator.ClearWindow();
                _userCommunicator.Print(customer.ToString());
                _userCommunicator.Print("Do you want to delete this customer? y/n");
                var canIDelete = _userCommunicator.GetYesOrNo();
                if (canIDelete)
                {
                    _customerStorage.Remove(customer);
                    _userCommunicator.Print("Customer deleted!");
                }
        }
        
        _userCommunicator.WaitForKey();
    }
}