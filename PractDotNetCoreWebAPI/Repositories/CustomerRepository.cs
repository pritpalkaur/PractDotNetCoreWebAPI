using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PractDotNetCoreWebAPI.Models;

namespace PractDotNetCoreWebAPI.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SystemContext _context;
        private readonly List<Customer> Customers = new()
        {
            new Customer { CustomerId = 1, CustomerName = "Potion", Age = 9, DOB = DateTime.Now },
            new Customer { CustomerId = 2, CustomerName = "Iron Sword", Age = 20, DOB = DateTime.Now },
            new Customer { CustomerId = 3, CustomerName = "Bronze Shield", Age = 18, DOB = DateTime.Now }
        };

        public CustomerRepository(SystemContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Customer>> GetCustomerAsync()
        {
            return await _context.Customer.ToListAsync(); 
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            var Customer = _context.Customer.Where(Customer => Customer.CustomerId == id).SingleOrDefault();
            return await Task.FromResult(Customer);
        }

        public async Task CreateCustomerAsync(Customer Customer)
        {
            _context.Customer.Add(Customer);
            await Task.CompletedTask;
        }

        public async Task UpdateCustomerAsync(Customer Customer)
        {
            var index = _context.Customer.FindAsync(Customer.CustomerId);
           await Task.CompletedTask;
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var index = _context.Customer.FindAsync(id);
            await Task.CompletedTask;
        }
    }
}