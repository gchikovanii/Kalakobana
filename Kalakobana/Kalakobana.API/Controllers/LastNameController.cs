using Kalakobana.Application.Countries.Commands;
using Kalakobana.Application.Countries.Queries;
using Kalakobana.Application.LastNames.Commands;
using Kalakobana.Application.LastNames.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kalakobana.API.Controllers
{
    public class LastNameController : BaseController
    {
        private readonly IMediator _mediator;

        public LastNameController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("ByLetter")]
        public async Task<IActionResult> GetFilteredLastNames([FromQuery] GetFilteredLastNamesQuery query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }
        [HttpGet]
        public async Task<IActionResult> GetLastNames(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetLastNamesQuery(), cancellationToken));
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateLastNameCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateLastNameCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] DeleteLastNameCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
    }
}
