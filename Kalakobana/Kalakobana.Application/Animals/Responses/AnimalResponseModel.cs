using Kalakobana.Domain.Animals;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.Animals.Responses
{
    public class AnimalResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public AnimalType AnimalType { get; set; }
    }
}
