
using Domain.Commen;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
            public string Name { get; set; } = null!;
            public string Desc { get; set; } = null!;
            public decimal Rate { get; set; }
    }
}
