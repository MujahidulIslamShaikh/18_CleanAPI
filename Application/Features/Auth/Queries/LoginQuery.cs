﻿using MediatR;

namespace Application.Features.Auth.Queries
{
    public class LoginQuery : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
