using Kalakobana.Domain.Plants;
using Kalakobana.Infrastructure.Repositories.Plants;
using Mapster;
using MediatR;

namespace Kalakobana.Application.Plants
{
    internal class CreatePlantCommandHandler : IRequestHandler<CreatePlantCommand, int>
    {
        private readonly IPlantRepository _plantRepository;

        public CreatePlantCommandHandler(IPlantRepository plantRepository)
        {
            _plantRepository = plantRepository;
        }
        public async Task<int> Handle(CreatePlantCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _plantRepository.CreateAsync(cancellationToken, request.Adapt<Plant>()).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
