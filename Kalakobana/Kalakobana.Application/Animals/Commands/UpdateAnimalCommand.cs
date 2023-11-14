using Kalakobana.Domain.Animals;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.Animals.Commands
{
    public class UpdateAnimalCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string NewName { get; set; }
        public AnimalType AnimalType { get; set; }
    }
}
