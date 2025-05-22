using Application.Features.Commands;
using Application.Features.Commands.EmployeeCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateEmployee")]
        public async Task<IActionResult> CreateProduct(CreateEmployeeCommand createEmployee, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(createEmployee, cancellationToken);
            return Ok(result);
        }
    }
}
