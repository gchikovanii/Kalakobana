using Kalakobana.Application.Animals.Responses;
using Kalakobana.Application.Countries.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.Animals.Queries
{
    public class GetAnimalsQuery : IRequest<List<AnimalResponseModel>>
    {

    }
}
