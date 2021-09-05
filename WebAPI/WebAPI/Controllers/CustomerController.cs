using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Repositories;
using WebAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository repository;
        private readonly ILogger<CustomerController> logger;
        public CustomerController(ICustomerRepository repository, ILogger<CustomerController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }
        // GET /items
        [HttpGet]
        public async Task<IEnumerable<Customer>> GetItemsAsync(string name = null)
        {
            var customers = await repository.GetCustomersAsync();

            if (!string.IsNullOrWhiteSpace(name))
            {
                customers = customers.Where(customer => customer.FullName.Contains(name, StringComparison.OrdinalIgnoreCase));
            }

            logger.LogInformation($"{DateTime.UtcNow.ToString("hh:mm:ss")}: Retrieved {customers.Count()} items");

            return customers;
        }
        [HttpGet]
       // [Authorize(Roles = "Admin")]
        [Route("ForAdmin")]
        public string GetForAdmin()
        {
            return "Web method for Admin";
        }
    }
}
