using Kalakobana.Application.Countries.Commands;
using Kalakobana.Application.Countries.Queries;
using Kalakobana.Application.Movies.Commands;
using Kalakobana.Application.Movies.Queries;
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
        [HttpGet("ByLetter")]
        public async Task<IActionResult> GetFilteredMovies([FromQuery] GetFilteredMoviesQuery query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }
        [HttpGet]
        public async Task<IActionResult> GetMovies(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetMoviesQuery(), cancellationToken));
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
