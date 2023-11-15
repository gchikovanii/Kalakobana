using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.UsersAggregate.Roles.Commands
{
    public class CreateUserRoleCommandHandler : IRequestHandler<CreateUserRoleCommand, bool>
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public CreateUserRoleCommandHandler(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<bool> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var roleExists = await _roleManager.FindByNameAsync(request.Role.ToString());
            if(roleExists == null)
            {
                await _roleManager.CreateAsync(new IdentityRole()
                {
                    Name = request.Role.ToString()
                });
                return true;
            }
            return false;
        }
    }
}
