using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Kalakobana.Application.Account
{
    public class LogoutUserCommandHandler : IRequestHandler<LogoutUserCommand>
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        public LogoutUserCommandHandler(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<Unit> Handle(LogoutUserCommand request, CancellationToken cancellationToken)
        {
            await _signInManager.SignOutAsync().ConfigureAwait(false);
            return Unit.Value;
        }
    }
}
