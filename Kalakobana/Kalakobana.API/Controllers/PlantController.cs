using Kalakobana.API.Infrastructure.constants;
using Kalakobana.Application.Countries.Commands;
using Kalakobana.Application.Countries.Queries;
using Kalakobana.Application.Plants.Commands;
using Kalakobana.Application.Plants.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = UserType.Admin)]
        [HttpGet("ByLetter")]
        public async Task<IActionResult> GetFilteredPlants([FromQuery] GetFilteredPlantsQuery query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }
        [Authorize(Roles = UserType.Admin)]
        [HttpGet]
        public async Task<IActionResult> GetPlants(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetPlantsQuery(), cancellationToken));
        }
        [Authorize(Roles = UserType.Admin)]
        [HttpPost]
        public async Task<IActionResult> Add(CreatePlantCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
        [Authorize(Roles = UserType.Admin)]
        [HttpPut]
        public async Task<IActionResult> Update(UpdatePlantCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
        [Authorize(Roles = UserType.Admin)]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] DeletePlantCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
    }
}
