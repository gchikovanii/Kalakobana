using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.Movies.Commands
{
    public class CreateMovieCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}