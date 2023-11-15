using Kalakobana.Application.UsersAggregate.Users.ResponseModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.UsersAggregate.Users.Queries
{
    public class GetUsersQuery : IRequest<List<UserRepsonseModel>>
    {
    }
}
