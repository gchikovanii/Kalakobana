using Kalakobana.Application.Errors.Custom;
using Kalakobana.Application.Movies.Commands;
using Kalakobana.Infrastructure.Repositories.Movies;
using Kalakobana.Infrastructure.Repositories.Plants;
using Kalakobana.Infrastructure.Units;
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
        private readonly IUnitOfWork _unitOfWork;
        public UpdatePlantCommandHandler(IPlantRepository plantRepository, IUnitOfWork unitOfWork)
        {
            _plantRepository = plantRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdatePlantCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _plantRepository.UpdateAsync(cancellationToken, request.Name, request.NewName).ConfigureAwait(false);
                var result = await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
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
