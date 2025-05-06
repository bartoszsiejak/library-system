using LibrarySystem.Models.CustomerModel;

namespace LibrarySystem.DataStructures;

public interface ICustomerStorage
{
    Dictionary<uint, Customer> Customers { get; }
    public void Add(Customer customer);
    void Remove(Customer customer);
    void LoadCustomers(Dictionary<uint, Customer> customers);
}