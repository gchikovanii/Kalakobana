using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.Cities.Commands
{
    public class CreateCityCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
