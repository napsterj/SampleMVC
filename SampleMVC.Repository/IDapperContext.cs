
using SampleMVC.Entities;

namespace SampleMVC.Repository
{
    public interface IDapperContext
    {
        Task<Customer> DeleteCustomer(Customer customer);
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(int Id);
        Task<int> SaveNewCustomer(Customer customer);
        Task<int> UpdateCustomer(Customer customer);
        Task<Customer> GetCustomerByEmail(string email);
    }
}