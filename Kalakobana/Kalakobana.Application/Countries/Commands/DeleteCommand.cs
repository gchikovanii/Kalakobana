using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.Countries.Commands
{
    public class DeleteCommand : IRequest<bool>
    {
        public string Name { get; set; }
    }
}
