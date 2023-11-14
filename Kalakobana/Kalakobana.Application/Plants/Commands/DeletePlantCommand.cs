using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.Plants.Commands
{
    public class DeletePlantCommand : IRequest<bool>
    {
        public string Name { get; set; }
    }
}