namespace Kalakobana.Application.Infrastructure.JWT
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(bool status, string email, List<string> roles);
    }
}
