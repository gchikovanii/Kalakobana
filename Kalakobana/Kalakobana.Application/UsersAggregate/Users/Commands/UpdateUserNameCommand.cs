using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.UsersAggregate.Users.Commands
{
    public class UpdateUserNameCommand : IRequest<bool>
    {
        public string Email { get; set; }
        public string NewUserName { get; set; }
    }
}
