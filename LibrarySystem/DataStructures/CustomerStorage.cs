using System.Data;
using LibrarySystem.Models;
using LibrarySystem.Models.CustomerModel;

namespace LibrarySystem.DataStructures;

public class CustomerStorage : ICustomerStorage
{
    public Dictionary<uint, Customer> Customers { get; private set; } = [];

    public void Add(Customer customer)
    {
        Customers.Add(customer.Id, customer);
    }
    
    public void Remove(Customer customer)
    {
        Customers.Remove(customer.Id);
    }

    public void LoadCustomers(Dictionary<uint, Customer> customers)
    {
       Customers = customers;
    }
}