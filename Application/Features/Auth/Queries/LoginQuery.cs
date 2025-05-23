using Domain.Entities;
using MediatR;

namespace Application.Features.Auth.Queries
{
    public class LoginQuery : IRequest<ApplicationUser>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public LoginQuery(string email, string password)
        {
            Email = email;
            Password = password;
        }

    }
}







