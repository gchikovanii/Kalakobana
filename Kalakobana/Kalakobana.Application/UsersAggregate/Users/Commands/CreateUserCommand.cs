using MediatR;


namespace Kalakobana.Application.Users.Commands
{
    public class CreateUserCommand : IRequest<bool>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
}
