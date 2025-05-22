using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.EmployeeCommands
{
    public class CreateEmployeeCommand : IRequest<int>
    {
        public string Name { get; set; } = null!;
        public string Role { get; set; } = null!;
        public int Salary { get; set; }

        internal class Handler : IRequestHandler<CreateEmployeeCommand, int>
        {
            private readonly IApplicationDbContext _context;//isme bhi ye class inject karenge
            private readonly IMapper _mapper;
            public Handler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
            {
    
                var employee = _mapper.Map<EmployeeModel>(request);

                await _context.Employees.AddAsync(employee);

                await _context.SaveChangesAsync(cancellationToken);
                return employee.Id;
            }
        }


    }
}
