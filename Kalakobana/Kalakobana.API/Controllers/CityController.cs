using Kalakobana.Application.Cities.Commands;
using Kalakobana.Application.Cities.Queries;
using Kalakobana.Application.Countries.Commands;
using Kalakobana.Application.Countries.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kalakobana.API.Controllers
{
    public class CityController : BaseController
    {
        private readonly IMediator _mediator;

        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("ByLetter")]
        public async Task<IActionResult> GetFilteredCities([FromQuery] GetFilteredCitiesQuery query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }
        [HttpGet]
        public async Task<IActionResult> GetCities(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetCitiesQuery(), cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateCityCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCityCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] DeleteCityCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
    }
}
