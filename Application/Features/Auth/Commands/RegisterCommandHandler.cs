using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, string>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public RegisterCommandHandler(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            //var user = _mapper.Map<ApplicationUser>(request);
            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
                return "User Registered Successfully";
            else
                //return string.Join(", ", result.Errors);
                return string.Join(", ", result.Errors.Select(e => e.Description));
        }


    }
}
