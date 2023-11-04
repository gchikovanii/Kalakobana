using Kalakobana.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Domain.Animals
{
    public class Animal : BaseEntity
    {
        public AnimalType AnimalType { get; set; }
    }
}
