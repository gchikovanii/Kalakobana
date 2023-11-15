using Kalakobana.Application.UsersAggregate.Roles.constants;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.Users.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public CreateUserCommandHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userExists = await _userManager.FindByEmailAsync(request.Email);
            if (userExists != null)
            {
                var currentUser = new IdentityUser()
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber
                };
                var createdUser = await _userManager.CreateAsync(currentUser, request.Password);
                if (createdUser.Succeeded)
                {
                    await _userManager.AddToRoleAsync(currentUser, Role.User.ToString()); 
                    return true;
                }
                return createdUser.Errors.Any();
            }
            return false;
        }
    }
}
