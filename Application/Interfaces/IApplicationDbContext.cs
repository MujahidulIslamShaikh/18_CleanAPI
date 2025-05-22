using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {

        DbSet<Product> Product { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<EmployeeModel> Employees { get; set; }




        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
