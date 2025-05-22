
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {
        internal class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
        {
            private readonly IApplicationDbContext _context; // iski humne injection karwali
            public GetAllProductsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var result = await _context.Product.ToListAsync(cancellationToken);
                return (result);
            }
        }
    }
}





