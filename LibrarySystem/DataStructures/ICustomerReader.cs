using LibrarySystem.Models;
using LibrarySystem.Models.CustomerModel;

namespace LibrarySystem.DataStructures;

public interface ICustomerReader
{
    Customer? ReadOrDefault(uint customerId);
}