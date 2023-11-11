using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.Countries.Commands
{
    public class UpdateCountryCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string NewName { get; set; }
    }
}
