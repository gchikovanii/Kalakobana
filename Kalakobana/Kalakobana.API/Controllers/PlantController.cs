using Kalakobana.Application.Countries.Commands;
using Kalakobana.Application.Plants;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kalakobana.API.Controllers
{
    public class PlantController : BaseController
    {
        private readonly IMediator _mediator;

        public PlantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreatePlantCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatePlantCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] DeletePlantCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
    }
}
