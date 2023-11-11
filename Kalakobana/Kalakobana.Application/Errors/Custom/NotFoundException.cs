using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.Errors.Custom
{
    public class NotFoundException : Exception
    {
        public string Code = "NotFoundException";

        public NotFoundException(string errorText) : base(errorText) { }
    }
}
