using System.Threading.Tasks;
using Application.Features.Commands;
using Application.Features.DepCommands;
using Application.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _mediator.Send(new GetAllDepartmentQuery());
            return Ok(result);
        }

        [HttpPost("CreateDepartment")]
        public async Task<IActionResult> CreateDepartment(CreateDepartmentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
