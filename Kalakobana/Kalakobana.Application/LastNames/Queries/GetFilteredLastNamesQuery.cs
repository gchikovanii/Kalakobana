using Kalakobana.Application.Countries.Responses;
using Kalakobana.Application.LastNames.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.LastNames.Queries
{
    public class GetFilteredLastNamesQuery : IRequest<List<LastNameReposne>>
    {
        public string Letter { get; set; }
    }
}