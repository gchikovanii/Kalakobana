using Kalakobana.Application.UsersAggregate.Roles.constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.UsersAggregate.Roles.Commands
{
    public class CreateUserRoleCommand : IRequest<bool>
    {
        public Role Role { get; set; }
    }
}
