using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Kalakobana.Application.UsersAggregate.Users.Commands
{
    public class UpdateUserNameCommandHandler : IRequestHandler<UpdateUserNameCommand, bool>
    {
        private readonly UserManager<IdentityUser> _userManager;
        public UpdateUserNameCommandHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<bool> Handle(UpdateUserNameCommand request, CancellationToken cancellationToken)
        {
            var userExists = await _userManager.FindByEmailAsync(request.Email);
            if (userExists != null)
            {
                var userNameExists = await _userManager.FindByNameAsync(request.NewUserName);
                if(userNameExists != null)
                {
                    //Already Exists Username
                }
                else
                {
                    userExists.UserName = request.NewUserName;
                    var result = await _userManager.UpdateAsync(userExists);
                    if (result.Succeeded)
                        return true;
                }
            }
            return false;
        }
    }
}
