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
    public class CreateAdminUserCommandHandler : IRequestHandler<CerateAdminUserCommand, bool>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public CreateAdminUserCommandHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> Handle(CerateAdminUserCommand request, CancellationToken cancellationToken)
        {
            var adminExists = await _userManager.FindByEmailAsync(request.Email);
            if (adminExists == null)
            {
                var currentUser = new IdentityUser()
                {
                    UserName = request.UserName,
                    Email = request.Email
                };
                var createdUser = await _userManager.CreateAsync(currentUser, request.Password);
                if (createdUser.Succeeded)
                {
                    await _userManager.AddToRoleAsync(currentUser, Role.Admin.ToString());
                    return true;
                }
                return createdUser.Errors.Any();
            }
            return false;
        }
    }
}
