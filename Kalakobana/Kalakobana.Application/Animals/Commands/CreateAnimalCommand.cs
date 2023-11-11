using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.Animals.Commands
{
    public class CreateAnimalCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
