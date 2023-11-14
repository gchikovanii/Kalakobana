﻿using Kalakobana.Application.Countries.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.Countries.Queries
{
    public class GetCountriesQuery : IRequest<List<CountryResponseModel>>
    {
    }
}
