using Kalakobana.Domain.Plants;
using Kalakobana.Infrastructure.Repositories.Plants;
using Kalakobana.Infrastructure.Units;
using Mapster;
using MediatR;

namespace Kalakobana.Application.Plants
{
    internal class CreatePlantCommandHandler : IRequestHandler<CreatePlantCommand, int>
    {
        private readonly IPlantRepository _plantRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreatePlantCommandHandler(IPlantRepository plantRepository, IUnitOfWork unitOfWork)
        {
            _plantRepository = plantRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(CreatePlantCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _plantRepository.CreateAsync(cancellationToken, request.Adapt<Plant>()).ConfigureAwait(false);
                await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
