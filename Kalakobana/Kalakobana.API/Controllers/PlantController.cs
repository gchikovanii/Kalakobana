using Kalakobana.Application.Countries.Commands;
using Kalakobana.Application.Countries.Queries;
using Kalakobana.Application.Plants.Commands;
using Kalakobana.Application.Plants.Queries;
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
        [HttpGet("ByLetter")]
        public async Task<IActionResult> GetFilteredPlants([FromQuery] GetFilteredPlantsQuery query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }
        [HttpGet]
        public async Task<IActionResult> GetPlants(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetPlantsQuery(), cancellationToken));
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
