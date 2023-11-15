using MediatR;

namespace Kalakobana.Application.Account
{
    public class LoginUserCommand : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
