﻿using Application.DTOs;
using Application.Features.Auth.Commands;
using Application.Features.Auth.Queries;
using Application.Services;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly AuthService _authService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthController(IMediator mediator, AuthService authService, UserManager<ApplicationUser> userManager)
        {
            _mediator = mediator;
            _authService = authService;
            _userManager = userManager;

        }

        // ✅ MediatR-based register
        [HttpPost("register")] 
        public async Task<IActionResult> Register(RegisterCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

  
   
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
        {

            
            // 🧠 Mapping LoginRequest to LoginQuery
            var query = new LoginQuery(request.Email, request.Password);
            
            var user = await _mediator.Send(query);

            if(user == null )
                return Unauthorized("Invalid credenrials");


             var token = _authService.GenerateToken(user);


            return Ok(new { Token = token });


        }


    }
}
