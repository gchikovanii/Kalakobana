using Kalakobana.Application.Countries.Commands;
using Kalakobana.Application.Movies.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kalakobana.API.Controllers
{
    public class MovieController : BaseController
    {
        private readonly IMediator _mediator;

        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateMovieCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateMovieCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] DeleteMovieCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
    }
}
