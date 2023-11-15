using Kalakobana.API.Infrastructure.constants;
using Kalakobana.Application.Animals.Commands;
using Kalakobana.Application.Animals.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = UserType.Admin)]
        [HttpGet]
        public async Task<IActionResult> GetAnimals(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAnimalsQuery(),cancellationToken));
        }
        [Authorize(Roles = UserType.Admin)]
        [HttpGet("ByCategory")]
        public async Task<IActionResult> GetAnimalsByLetter([FromQuery] GetAnimalsByCategoryQuery query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }
        [Authorize(Roles = UserType.Admin)]
        [HttpGet("ByLetter")]
        public async Task<IActionResult> GetAnimalsByCategory([FromQuery] GetFilteredAnimalsQuery query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }
        [Authorize(Roles = UserType.Admin)]
        [HttpPost]
        public async Task<IActionResult> Add(CreateAnimalCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
        [Authorize(Roles = UserType.Admin)]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAnimalCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
        [Authorize(Roles = UserType.Admin)]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] DeleteAnimalCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
    }
}

