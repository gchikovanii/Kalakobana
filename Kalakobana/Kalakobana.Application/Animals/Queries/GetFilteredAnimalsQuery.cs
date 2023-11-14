using Kalakobana.Application.Animals.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.Animals.Queries
{
    public class GetFilteredAnimalsQuery : IRequest<List<AnimalResponseModel>>
    {
        public char Letter { get; set; }
    }
}
