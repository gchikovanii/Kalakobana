using Kalakobana.Application.Countries.Responses;
using Kalakobana.Application.FirstNames.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.FirstNames.Queries
{
    public class GetFirstNamesQuery : IRequest<List<FirstNameReposneModel>>
    {
    }
}