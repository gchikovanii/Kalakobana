using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.Cities.Commands
{
    public class DeleteCityCommand : IRequest<bool>
    {
        public string Name { get; set; }
    }
}