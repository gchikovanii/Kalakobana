using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.Infrastructure.Errors.Custom
{
    public class AlreadyExistsException : Exception
    {
        public string Code = "AlreadyExistsException";

        public AlreadyExistsException(string errorText) : base(errorText) { }
    }
}
