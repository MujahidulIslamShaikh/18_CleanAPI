
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Commands
{
    public class GetAllDepartmentQuery : IRequest<IEnumerable<Department>>
    {
        internal class Handler : IRequestHandler<GetAllDepartmentQuery, IEnumerable<Department>>
        {
            private readonly IApplicationDbContext _context; // iski humne injection karwali
            public Handler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Department>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
            {
                var result = await _context.Departments.ToListAsync(cancellationToken);
                return (result);
            }
        }
    }

 

}





