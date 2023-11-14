using Kalakobana.Application.Countries.Commands;
using Kalakobana.Application.Countries.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kalakobana.API.Controllers
{
    public class CountryController : BaseController
    {
        private readonly IMediator _mediator;

        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("ByName")]
        public async Task<IActionResult> GetCountry([FromQuery] GetCountryQuery query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }
        [HttpGet]
        public async Task<IActionResult> GetCountries(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetCountriesQuery(),cancellationToken));
        }
        

        [HttpPost]
        public async Task<IActionResult> Add(CreateCountryCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));    
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCountryCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm]DeleteCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
    }
}
