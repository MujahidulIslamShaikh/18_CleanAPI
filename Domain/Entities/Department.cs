using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Department
    {
        [Key]
        public int DepId { get; set; }
        public string Name { get; set; } = null!;
        public string code { get; set; } = null!;
    }
}
