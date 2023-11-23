using Kalakobana.Infrastructure.Localizations;

namespace Kalakobana.Infrastructure.Errors
{
    public class AlreadyExists : Exception
    {
        public string Code = ErrorMessages.AlreadyExistsCode;
        public AlreadyExists(string message) : base(message)
        {
        }
    }
}
