using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PractDotNetCoreWebAPI.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string CustomerName { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime DOB { get; set; } 

        [Column(TypeName = "nvarchar(20)")]
        public int Age { get; set; }
    }
}
