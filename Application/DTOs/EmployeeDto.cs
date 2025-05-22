using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class EmployeeDto
    {

        public string Name { get; set; } = null!;
        public string Role { get; set; } = null!;
        public int Salary { get; set; }
    }
}
