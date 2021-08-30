using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PractDotNetCoreWebAPI.Controllers;
using PractDotNetCoreWebAPI.Repositories;
using PractDotNetCoreWebAPI.Dtos;
using PractDotNetCoreWebAPI.Models;
using PractDotNetCoreWebAPI.dto;

namespace PractDotNetCoreWebAPI.Controllers
{
    [ApiController]
    [Route("Customers")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository repository;
        private readonly ILogger<CustomerController> logger;

        public CustomerController(ICustomerRepository repository, ILogger<CustomerController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        // GET /Customers
        [HttpGet]
        public async Task<IEnumerable<CustomerDto>> GetCustomersAsync(string name = null)
        {
            var Customers = (await repository.GetCustomerAsync())
                        .Select(Customer => Customer.AsDto());

            if (!string.IsNullOrWhiteSpace(name))
            {
                Customers = Customers.Where(Customer => Customer.CustomerName.Contains(name, StringComparison.OrdinalIgnoreCase));
            }

            logger.LogInformation($"{DateTime.UtcNow.ToString("hh:mm:ss")}: Retrieved {Customers.Count()} Customers");

            return Customers;
        }

        // GET /Customers/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomerAsync(int id)
        {
            var Customer = await repository.GetCustomerAsync(id);

            if (Customer is null)
            {
                return NotFound();
            }

            return Customer.AsDto();
        }

        // POST /Customers
        [HttpPost]
        public async Task<ActionResult<CustomerDto>> CreateCustomerAsync(CreateCustomerDto CustomerDto)
        {
            Customer Customer = new()
            {
                CustomerId = CustomerDto.CustomerId,
                CustomerName = CustomerDto.CustomerName,
                DOB = CustomerDto.DOB,
                Age = CustomerDto.Age,
            };

            await repository.CreateCustomerAsync(Customer);

            return CreatedAtAction(nameof(GetCustomerAsync), new { id = Customer.CustomerId }, Customer.AsDto());
        }

        // PUT /Customers/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCustomerAsync(int id, UpdateCustomerDto CustomerDto)
        {
            var existingCustomer = await repository.GetCustomerAsync(id);

            if (existingCustomer is null)
            {
                return NotFound();
            }

            //existingCustomer.Name = CustomerDto.Name;
            //existingCustomer.Price = CustomerDto.Price;

            await repository.UpdateCustomerAsync(existingCustomer);

            return NoContent();
        }

        // DELETE /Customers/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomerAsync(int id)
        {
            var existingCustomer = await repository.GetCustomerAsync(id);

            if (existingCustomer is null)
            {
                return NotFound();
            }

            await repository.DeleteCustomerAsync(id);

            return NoContent();
        }
    }
}