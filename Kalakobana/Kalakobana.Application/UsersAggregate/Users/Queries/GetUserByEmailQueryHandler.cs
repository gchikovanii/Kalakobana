using Kalakobana.Application.UsersAggregate.Users.ResponseModel;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.UsersAggregate.Users.Queries
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserRepsonseModel>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public GetUserByEmailQueryHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<UserRepsonseModel> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            return user.Adapt<UserRepsonseModel>();
        }
    }
}
