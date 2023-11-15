using Kalakobana.Application.UsersAggregate.Users.ResponseModel;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Kalakobana.Application.UsersAggregate.Users.Queries
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserRepsonseModel>>
    {
        private readonly UserManager<IdentityUser> _userManager;
        public GetUsersQueryHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<List<UserRepsonseModel>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userManager.Users.ToListAsync();
            return users.Adapt<List<UserRepsonseModel>>();
        }
    }
}
