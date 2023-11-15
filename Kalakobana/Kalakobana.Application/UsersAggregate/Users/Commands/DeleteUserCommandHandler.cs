using MediatR;
using Microsoft.AspNetCore.Identity;


namespace Kalakobana.Application.UsersAggregate.Users.Commands
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly UserManager<IdentityUser> _userManager;
        public DeleteUserCommandHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var userExists = await _userManager.FindByEmailAsync(request.Email);
            if(userExists != null)
            {
                var result = await _userManager.DeleteAsync(userExists);
                if(result.Succeeded)
                    return true;
               
            }
            return false;
        }
    }
}
