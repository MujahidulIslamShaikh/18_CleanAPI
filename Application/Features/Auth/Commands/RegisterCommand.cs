using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands   
{
    public class RegisterCommand : IRequest<string>
    {
        public string Email { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
    }
}
