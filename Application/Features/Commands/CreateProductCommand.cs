using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        //public string Remarks { get; set; }
        public decimal Rate { get; set; }

        internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
        {
            private readonly IApplicationDbContext _context;//isme bhi ye class inject karenge
            private readonly IMapper _mapper;

            public CreateProductCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
                {
                //Without Mapping
                //var product = new Product();
                //product.Name = request.Name;
                //product.Desc = request.Desc;
                //product.Rate = request.Rate;      
                var product = _mapper.Map<Product>(request);

                await _context.Product.AddAsync(product);
                
                await _context.SaveChangesAsync(cancellationToken);
                return product.Id;
            }
        }
    }
}
