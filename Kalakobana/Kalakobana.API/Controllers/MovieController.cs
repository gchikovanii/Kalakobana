using Kalakobana.API.Infrastructure.constants;
using Kalakobana.Application.Countries.Commands;
using Kalakobana.Application.Countries.Queries;
using Kalakobana.Application.Movies.Commands;
using Kalakobana.Application.Movies.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = UserType.Admin)]
        [HttpGet("ByLetter")]
        public async Task<IActionResult> GetFilteredMovies([FromQuery] GetFilteredMoviesQuery query, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(query, cancellationToken));
        }
        [Authorize(Roles = UserType.Admin)]
        [HttpGet]
        public async Task<IActionResult> GetMovies(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetMoviesQuery(), cancellationToken));
        }
        [Authorize(Roles = UserType.Admin)]
        [HttpPost]
        public async Task<IActionResult> Add(CreateMovieCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
        [Authorize(Roles = UserType.Admin)]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateMovieCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
        [Authorize(Roles = UserType.Admin)]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] DeleteMovieCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
    }
}
