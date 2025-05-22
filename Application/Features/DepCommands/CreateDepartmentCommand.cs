using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DepCommands
{
    public class CreateDepartmentCommand : IRequest<int>
    {

        public string Name { get; set; }
        public string code { get; set; }

        public class Handler : IRequestHandler<CreateDepartmentCommand, int>
        {
            private readonly IMapper _mapper;
            private readonly IApplicationDbContext _context;
            public Handler(IMapper mapper, IApplicationDbContext context)
            {
                _mapper = mapper;
                _context = context;
            }
            public async Task<int> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
            {
                var department = _mapper.Map<Department>(request);
                await _context.Departments.AddAsync(department);
                await _context.SaveChangesAsync(cancellationToken);
                return department.DepId;
            }
        }

    }
}
