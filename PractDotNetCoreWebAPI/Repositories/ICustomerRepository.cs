using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PractDotNetCoreWebAPI.Models;

namespace PractDotNetCoreWebAPI.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomerAsync(int id);
        Task<IEnumerable<Customer>> GetCustomerAsync();
        Task CreateCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int id);
    }
}