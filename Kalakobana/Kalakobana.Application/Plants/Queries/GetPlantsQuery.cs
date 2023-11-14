using Kalakobana.Application.Countries.Responses;
using Kalakobana.Application.Plants.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.Plants.Queries
{
    public class GetPlantsQuery : IRequest<List<PlantReponseModel>>
    {
    }
}
