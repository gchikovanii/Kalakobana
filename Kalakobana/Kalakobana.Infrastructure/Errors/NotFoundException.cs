using Kalakobana.Infrastructure.Localizations;

namespace Kalakobana.Infrastructure.Errors
{
    public class NotFoundException : Exception
    {
        public string Code = ErrorMessages.NotFound;
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
