using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class DepartmentDto
    {
        public int DepId { get; set; }
        public string Name { get; set; } = null!;
        public string code { get; set; } = null!;
    }
}
