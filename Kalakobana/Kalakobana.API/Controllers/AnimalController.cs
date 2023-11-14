using Kalakobana.Application.Animals.Commands;
using Kalakobana.Application.Animals.Queries;
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

        [HttpGet]
        public async Task<IActionResult> GetAnimals(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAnimalsQuery(),cancellationToken));
        }
        [HttpGet("ByCategory")]
        public async Task<IActionResult> GetAnimalsByLetter([FromQuery] GetAnimalsByCategoryQuery query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }
        [HttpGet("ByLetter")]
        public async Task<IActionResult> GetAnimalsByCategory([FromQuery] GetFilteredAnimalsQuery query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
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

