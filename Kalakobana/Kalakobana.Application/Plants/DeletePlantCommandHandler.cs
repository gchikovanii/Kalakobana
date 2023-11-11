using Kalakobana.Application.Errors.Custom;
using Kalakobana.Infrastructure.Repositories.Plants;
using MediatR;


namespace Kalakobana.Application.Plants
{
    internal class DeletePlantCommandHandler : IRequestHandler<DeletePlantCommand, bool>
    {
        private readonly IPlantRepository _plantRepository;

        public DeletePlantCommandHandler(IPlantRepository plantRepository)
        {
            _plantRepository = plantRepository;
        }

        public async Task<bool> Handle(DeletePlantCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _plantRepository.DeleteAsync(cancellationToken, request.Name);
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
