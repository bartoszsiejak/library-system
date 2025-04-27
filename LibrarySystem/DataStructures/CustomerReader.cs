using LibrarySystem.Models;
using LibrarySystem.Models.CustomerModel;

namespace LibrarySystem.DataStructures;

public class CustomerReader(CustomerStorage customerStorage) : ICustomerReader
{
    private readonly CustomerStorage _customerStorage = customerStorage;
    
    public Customer? ReadOrDefault(uint customerId)
     {
         return _customerStorage.Customers.GetValueOrDefault(customerId);
     }
 }