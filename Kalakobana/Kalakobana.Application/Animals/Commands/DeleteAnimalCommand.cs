using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.Animals.Commands
{
    public class DeleteAnimalCommand : IRequest<bool>
    {
        public string Name { get; set; }
    }
}
