using Domain.Commen;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EmployeeModel :  BaseEntity
    {
        [Key]
        public int EmpId { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]       
        public string Role { get; set; } = null!;
        [Required]  
        public int Salary { get; set; }

    }
}
