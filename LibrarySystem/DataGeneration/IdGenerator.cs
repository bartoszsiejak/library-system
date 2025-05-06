using LibrarySystem.DataStructures;
using LibrarySystem.Menus.Options.CustomerOption;

namespace LibrarySystem.DataGeneration;

public class CustomerIdGenerator(ICustomerStorage customerStorage) : IIdGenerator
{
    private readonly ICustomerStorage _customerStorage = customerStorage;

    public uint GetId()
    {
        checked
        {   
            return _customerStorage.Customers.Keys.Count != 0 ?
                _customerStorage.Customers.Keys.Max() + 1 :
                0u;
        }
    }
}