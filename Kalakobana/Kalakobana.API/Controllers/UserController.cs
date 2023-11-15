using Kalakobana.API.Infrastructure.constants;
using Kalakobana.Application.Account;
using Kalakobana.Application.Animals.Commands;
using Kalakobana.Application.Users.Commands;
using Kalakobana.Application.UsersAggregate.Roles.Commands;
using Kalakobana.Application.UsersAggregate.Users.Commands;
using Kalakobana.Application.UsersAggregate.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kalakobana.API.Controllers
{
    public class UserController : BaseController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize(Roles = UserType.Admin)]
        [HttpGet("ByEmail")]
        public async Task<IActionResult> GetByEmail([FromQuery]GetUserByEmailQuery input)
        {
            return Ok(await _mediator.Send(input));
        }
        [Authorize(Roles = UserType.Admin)]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _mediator.Send(new GetUsersQuery()));
        }
        [Authorize(Roles = UserType.Admin)]
        [HttpPost("Roles")]
        public async Task<IActionResult> CreateRoles(CreateUserRoleCommand input)
        {
            return Ok(await _mediator.Send(input));
        }
        [Authorize(Roles = UserType.Admin)]
        [HttpPost("User")]
        public async Task<IActionResult> AddUser(CreateUserCommand input)
        {
            return Ok(await _mediator.Send(input));
        }
        [Authorize(Roles = UserType.Admin)]
        [HttpPost("Admin")]
        public async Task<IActionResult> AddAdmin(CerateAdminUserCommand input)
        {
            return Ok(await _mediator.Send(input));
        }
        [Authorize(Roles = UserType.Admin)]
        [HttpPut("UpdateUserName")]
        public async Task<IActionResult> Update(UpdateUserNameCommand input)
        {
            return Ok(await _mediator.Send(input));
        }
        [Authorize(Roles = UserType.Admin)]
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteUserCommand input)
        {
            return Ok(await _mediator.Send(input));
        }

    }
}
