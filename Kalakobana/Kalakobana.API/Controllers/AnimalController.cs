using Kalakobana.Application.Animals.Commands;
using Kalakobana.Application.Countries.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kalakobana.API.Controllers
{
    public class AnimalController : BaseController
    {
        private readonly IMediator _mediator;

        public AnimalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateAnimalCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAnimalCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] DeleteAnimalCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
    }
}

