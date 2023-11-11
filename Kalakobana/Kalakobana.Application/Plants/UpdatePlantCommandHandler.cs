using Kalakobana.Application.Errors.Custom;
using Kalakobana.Application.Movies.Commands;
using Kalakobana.Infrastructure.Repositories.Movies;
using Kalakobana.Infrastructure.Repositories.Plants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.Plants
{
    public class UpdatePlantCommandHandler : IRequestHandler<UpdatePlantCommand, bool>
    {
        private readonly IPlantRepository _plantRepository;

        public UpdatePlantCommandHandler(IPlantRepository plantRepository)
        {
            _plantRepository = plantRepository;
        }

        public async Task<bool> Handle(UpdatePlantCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _plantRepository.UpdateAsync(cancellationToken, request.Name, request.NewName).ConfigureAwait(false);

                if (result == false)
                    throw new NotFoundException("Not Found");
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
