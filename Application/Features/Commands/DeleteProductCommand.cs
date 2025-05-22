using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Commands
{
    public class DeleteProductCommand : IRequest<int>
    {
        public int Id { get; set; } // yaha per DeleteProductCommand.cs me only hame "Id" ki hi zaroorat hai
        // so isliye yaha per Id ki property hi define karege aur use bhi karege


        internal class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, int>
        {
            private readonly IApplicationDbContext _context;//isme bhi ye class inject karenge

            public DeleteProductCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
            {
                var product = await _context.Product.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
                if (product == null)    
                {
                    return default;
                }
                _context.Product.Remove(product);
                await _context.SaveChangesAsync(cancellationToken);
                return product.Id;
                // logic
                //return 1;
            }
        }
    }
}
