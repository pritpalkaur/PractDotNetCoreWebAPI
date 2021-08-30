using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PractDotNetCoreWebAPI.Dtos
{
        public record CustomerDto([Required] int CustomerId, [Required] string CustomerName, DateTime DOB, [Range(1, 100)] int Age);
        public record CreateCustomerDto([Required] int CustomerId, [Required] string CustomerName, DateTime DOB, [Range(1, 100)] int Age);
        public record UpdateCustomerDto([Required] int CustomerId, [Required] string CustomerName, DateTime DOB, [Range(1, 100)] int Age);

}
