using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.LastNames.Commands
{
    public class DeleteLastNameCommand : IRequest<bool>
    {
        public string Name { get; set; }
    }
}