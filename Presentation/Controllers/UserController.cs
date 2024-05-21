using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Registration.Application.Commands;


namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        protected readonly IMediator _mediator;
        protected readonly IValidator<UserCreateCommand> _validator;
        public UserController(IMediator mediator  , IValidator<UserCreateCommand> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateCommand command)
        {
            var result = await _validator.ValidateAsync(command);
            if (!result.IsValid)
            {
                return BadRequest(result.ToDictionary());
            }
            await _mediator.Send(command);
            return Created();
        }
    }
}
