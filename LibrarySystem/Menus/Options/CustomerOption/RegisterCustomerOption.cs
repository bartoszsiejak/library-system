using LibrarySystem.DataGeneration;
using LibrarySystem.DataStructures;
using LibrarySystem.Models.CustomerModel;
using LibrarySystem.UserCommunication;

namespace LibrarySystem.Menus.Options.CustomerOption;

public class RegisterCustomerOption(
    IUserCommunicator userCommunicator,
    IIdGenerator idGenerator,
    ICustomerStorage customerStorage) 
    : IOption
{
    private readonly IUserCommunicator _userCommunicator = userCommunicator;
    private readonly IIdGenerator _idGenerator = idGenerator;
    private readonly ICustomerStorage _customerStorage = customerStorage;

    public void Run()
    {
        _userCommunicator.ClearWindow();
        var firstName = _userCommunicator.ReadValidFromUser("name", (input) => input.Length > 1  && input.All(char.IsLetter));
        var lastName = _userCommunicator.ReadValidFromUser("surname", (input) => input.Length > 1  && input.All(char.IsLetter));
        var customerId = _idGenerator.GetId();
        
        var customer = new Customer(customerId, firstName, lastName);
        _customerStorage.Add(customer);
        
        _userCommunicator.ClearWindow();
        _userCommunicator.Print(customer.ToString());
        _userCommunicator.Print("Customer added!");
        _userCommunicator.WaitForKey();
    }
}