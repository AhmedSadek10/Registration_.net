using MediatR;
using Microsoft.AspNetCore.Mvc;
using Registration.Application.Queries;


namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookUpController : ControllerBase
    {
        protected readonly IMediator _mediator;

        public LookUpController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("cities/{governateId:int}")]
        public async Task<IActionResult> GetCities(int governateId)
        {
           var result = await _mediator.Send(new GetCitiesQuery(governateId));
           return Ok(result);
        }
        [HttpGet("Governates")]
        public async Task<IActionResult> GetGovernates()
        {
            var result = await _mediator.Send(new GetGovernatesQuery());
            return Ok(result);
        }
    }
}
