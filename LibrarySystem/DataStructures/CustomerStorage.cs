using System.Data;
using LibrarySystem.Models;
using LibrarySystem.Models.CustomerModel;

namespace LibrarySystem.DataStructures;

public class CustomerStorage(Dictionary<uint, Customer>  customers) : ICustomerStorage
{
    public Dictionary<uint, Customer> Customers { get; } = customers;

    public void Add(Customer customer)
    {
        Customers.Add(customer.Id, customer);
    }
}