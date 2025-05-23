using Application.DTOs;
using Application.Features.Auth.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Auth.Handlers
{
    // public class LoginQueryHandler : IRequestHandler<LoginQuery, string>
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ApplicationUser?>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginQueryHandler(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // public async Task<string> Handle(LoginQuery request, CancellationToken cancellationToken)
        public async Task<ApplicationUser?> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            //var user = await _userManager.FindByEmailAsync(request.Email);
            //if (user == null)
            //    return "Invalid Credentials";
            //var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);
            //if (result.Succeeded)
            //    return "Login Successful";
            //else
            //    return "Invalid Credentials";


            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
                return null;

            return user;

        }
    }
}










