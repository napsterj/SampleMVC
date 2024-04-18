using SampleMVC.Entities;
using SampleMVC.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMVC.Service
{
    public interface ICustomerService
    {
        Task<int> AddNewCustomer(Customer customer);
        Task<int> UpdateCustomer(Customer customer);
        Task<Customer> DeleteCustomer(Customer customer);
        Task<Customer> GetCustomerById(int id);
        Task<Customer> GetCustomerByEmail(string email);
        Task<IEnumerable<Customer>> GetAllCustomers();
    }
}
