using Kalakobana.Application.Infrastructure.JWT;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.Account
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;
        public LoginUserCommandHandler(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }

        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            var result = await _signInManager.PasswordSignInAsync(user, request.Password, true, false);
            var roles = await _userManager.GetRolesAsync(user);
            return _jwtAuthenticationManager.Authenticate(result.Succeeded, request.Email, roles.ToList());
        }
    }
}
