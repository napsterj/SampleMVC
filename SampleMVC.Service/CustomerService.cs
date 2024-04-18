using SampleMVC.Entities;
using SampleMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMVC.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IDapperContext _context;

        public CustomerService(IDapperContext context)
        {
            _context = context;
        }
        public Task<int> AddNewCustomer(Customer customer)
        {
            return _context.SaveNewCustomer(customer);
        }

        public async Task<Customer> DeleteCustomer(Customer customer)
        {
            var existingCustomer = await GetCustomerById(customer.Id);
            if (existingCustomer == null)
            {
                return new Customer();
            }
            return await _context.DeleteCustomer(customer);
        }

        public Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return _context.GetAllCustomers();
        }

        public Task<Customer> GetCustomerByEmail(string email)
        {
            return _context.GetCustomerByEmail(email);
        }

        public Task<Customer> GetCustomerById(int id)
        {
            return _context.GetCustomerById(id);
        }

        public async Task<int> UpdateCustomer(Customer customer)
        {
            var existingCustomer = await GetCustomerById(customer.Id);
            if (existingCustomer == null) 
            {
                return 0;
            }
            return await _context.UpdateCustomer(existingCustomer);
        }
    }
}
