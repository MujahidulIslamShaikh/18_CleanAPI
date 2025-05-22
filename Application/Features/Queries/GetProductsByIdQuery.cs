
using System.Reflection.Metadata.Ecma335;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries
{
    public class GetProductsByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
        internal class GetProductsByIdQueryHandler : IRequestHandler<GetProductsByIdQuery, Product>
        {
            private readonly IApplicationDbContext _context; // iski humne injection karwali
            public GetProductsByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Product> Handle(GetProductsByIdQuery request, CancellationToken cancellationToken)
            {
                var result = await _context.Product.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
                return (result);
            }
            
        }
        
    }



}








//public class GetProductsByIdQuery : IRequest<IEnumerable<Product>>
//{
//    internal class GetProductsByIdQueryHandler : IRequestHandler<GetProductsByIdQuery, IEnumerable<Product>>
//    {
//        public async Task<IEnumerable<Product>> Handle(GetProductsByIdQuery request, CancellationToken cancellationToken)
//        {
//            var list = new List<Product>();
//            for (int i = 0; i < 100; i++)
//            {
//                var prod = new Product();
//                prod.Name = "Mobile";
//                prod.Desc = "Test mobile lorem ipsum";
//                prod.Rate = 100 + i;
//                list.Add(prod);
//            }
//            return list;
//        }
//    }
//    public class Product
//    {
//        public string Name { get; set; }
//        public string Desc { get; set; }
//        public decimal Rate { get; set; }

//    }
//}