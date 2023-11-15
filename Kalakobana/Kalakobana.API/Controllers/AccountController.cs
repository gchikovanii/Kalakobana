using Kalakobana.Application.Account;
using Kalakobana.Application.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kalakobana.API.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> Register(CreateUserCommand input)
        {
            return Ok(await _mediator.Send(input));
        }
        [HttpPost("Login")]
        public async Task<IActionResult> LogIn(LoginUserCommand input)
        {
            return Ok(await _mediator.Send(input));
        }

    }
}
