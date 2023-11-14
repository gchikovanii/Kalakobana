using Kalakobana.Application.Errors.Custom;
using Kalakobana.Infrastructure.Repositories.Plants;
using Kalakobana.Infrastructure.Units;
using MediatR;


namespace Kalakobana.Application.Plants
{
    internal class DeletePlantCommandHandler : IRequestHandler<DeletePlantCommand, bool>
    {
        private readonly IPlantRepository _plantRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeletePlantCommandHandler(IPlantRepository plantRepository, IUnitOfWork unitOfWork)
        {
            _plantRepository = plantRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeletePlantCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _plantRepository.DeleteAsync(cancellationToken, request.Name);
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
