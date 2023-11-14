using Kalakobana.Application.Countries.Commands;
using Kalakobana.Application.FirstNames.Commands;
using MediatR;
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

        [HttpPost]
        public async Task<IActionResult> Add(CreateFirstNameCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateFirstNameCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] DeleteFirstNameCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
    }
}
