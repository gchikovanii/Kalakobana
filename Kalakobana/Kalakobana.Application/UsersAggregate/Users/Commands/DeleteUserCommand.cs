using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.UsersAggregate.Users.Commands
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public string Email { get; set; }
    }
}
