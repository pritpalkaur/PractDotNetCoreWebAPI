using PractDotNetCoreWebAPI.Dtos;
using PractDotNetCoreWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractDotNetCoreWebAPI.dto
{
    public static class Extensions
    {
        public static CustomerDto AsDto(this Customer customer)
        {
            return new CustomerDto(customer.CustomerId, customer.CustomerName, customer.DOB, customer.Age);
        }
    }
}
