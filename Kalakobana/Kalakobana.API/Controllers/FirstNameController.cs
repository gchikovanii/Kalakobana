using Kalakobana.API.Infrastructure.constants;
using Kalakobana.Application.Countries.Commands;
using Kalakobana.Application.Countries.Queries;
using Kalakobana.Application.FirstNames.Commands;
using Kalakobana.Application.FirstNames.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kalakobana.API.Controllers
{
    public class FirstNameController : BaseController
    {
        private readonly IMediator _mediator;

        public FirstNameController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize(Roles = UserType.Admin)]
        [HttpGet("ByLetter")]
        public async Task<IActionResult> GetFilteredNames([FromQuery] GetFilteredFirstNamesQuery query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }
        [Authorize(Roles = UserType.Admin)]
        [HttpGet]
        public async Task<IActionResult> GetNames(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetFirstNamesQuery(), cancellationToken));
        }
        [Authorize(Roles = UserType.Admin)]
        [HttpPost]
        public async Task<IActionResult> Add(CreateFirstNameCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
        [Authorize(Roles = UserType.Admin)]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateFirstNameCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
        [Authorize(Roles = UserType.Admin)]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] DeleteFirstNameCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
    }
}
