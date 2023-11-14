using Kalakobana.Domain.Plants;
using Kalakobana.Infrastructure.Repositories.Plants;
using Kalakobana.Infrastructure.Units;
using Mapster;
using MediatR;

namespace Kalakobana.Application.Plants.Commands
{
    internal class CreatePlantCommandHandler : IRequestHandler<CreatePlantCommand, bool>
    {
        private readonly IPlantRepository _plantRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreatePlantCommandHandler(IPlantRepository plantRepository, IUnitOfWork unitOfWork)
        {
            _plantRepository = plantRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(CreatePlantCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _plantRepository.CreateAsync(cancellationToken, request.Adapt<Plant>()).ConfigureAwait(false);
                var result = await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
