using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Commands
{
    public class UpdateProductCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public decimal Rate { get; set; }

        internal class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
        {
            private readonly IApplicationDbContext _context;//isme bhi ye class inject karenge

            public UpdateProductCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                var product = await _context.Product.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
                if (product != null)
                {
                    product.Name = request.Name;
                    product.Desc = request.Desc;
                    product.Rate = request.Rate;
                    await _context.SaveChangesAsync(cancellationToken);
                    return product.Id;
                }
                return default;
                // logic
                //return 1;
            }
        }
    }
}
