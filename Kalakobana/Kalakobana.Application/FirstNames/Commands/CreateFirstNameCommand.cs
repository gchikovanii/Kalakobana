using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.FirstNames.Commands
{
    public class CreateFirstNameCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}