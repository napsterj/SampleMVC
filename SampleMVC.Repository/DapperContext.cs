using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;
using SampleMVC.Entities;
namespace SampleMVC.Repository
{
    public class DapperContext : IDapperContext
    {
        private readonly string connectionString = string.Empty;
        public DapperContext()
        {
            connectionString = Environment.GetEnvironmentVariable("SqliteConnString");
        }

        public async Task<int> SaveNewCustomer(Customer customer)
        {
            using (IDbConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var sb = new StringBuilder();
                sb.AppendLine("INSERT INTO CUSTOMERS (FirstName,LastName,Email,Phone,DateOfBirth,GENDER,UPLOADEDPHOTOURL)")
                  .AppendLine($"VALUES({customer.FirstName}," +
                                     $"{customer.LastName}," +
                                     $"{customer.Email}," +
                                     $"{customer.Phone}," +
                                     $"{customer.DateOfBirth}," +
                                     $"{customer.Gender}," +
                                     $"{customer.UploadedPhotoUrl}" +
                                     $")");

                return await connection.ExecuteScalarAsync<int>(sb.ToString());
            }
        }

        public async Task<int> UpdateCustomer(Customer customer)
        {
            using (IDbConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var sql = new StringBuilder();
                sql.AppendLine("UPDATE CUSTOMERS SET email,Phone,DateOfBirth,GENDER,UPLOADEDPHOTOURL)")
                  .AppendLine($"FirstName={customer.FirstName}," +
                              $"LastName={customer.LastName}," +
                              $"Email={customer.Email}," +
                              $"Phone={customer.Phone}," +
                              $"DateOfBirth={customer.DateOfBirth}," +
                              $"Gender={customer.Gender}," +
                              $"UploadedPhotoUrl={customer.UploadedPhotoUrl}" +
                              $"WHERE ID={customer.Id}");

                return await connection.ExecuteScalarAsync<int>(sql.ToString());
            }
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            using (IDbConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var sql = new StringBuilder();
                sql.AppendLine("SELECT * FROM CUSTOMERS");
                return await connection.QueryAsync<Customer>(sql.ToString());
            }
        }

        public async Task<Customer> GetCustomerById(int Id)
        {
            using (IDbConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var sql = new StringBuilder();
                sql.AppendLine($"SELECT * FROM CUSTOMERS WHERE ID={Id}");
                return await connection.QueryFirstOrDefaultAsync<Customer>(sql.ToString());
            }
        }

        public async Task<Customer> DeleteCustomer(Customer customer)
        {
            using (IDbConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var sql = new StringBuilder();
                sql.AppendLine($"DELETE FROM CUSTOMERS WHERE ID = {customer.Id}");
                return await connection.ExecuteScalarAsync<Customer>(sql.ToString());
            }
        }

        public async Task<Customer> GetCustomerByEmail(string email)
        {
            using (IDbConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var sql = new StringBuilder();
                sql.AppendLine($"SELECT * FROM CUSTOMERS WHERE Email={email}");
                return await connection.QueryFirstOrDefaultAsync<Customer>(sql.ToString());
            }
        }
    }
}
