using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.Errors.Custom
{
    internal class CriticalException : Exception
    {
        public string Code = "CriticalException";

        public CriticalException(string errorText) : base(errorText) { }
    }
}
