using Kalakobana.Application.Infrastructure.Errors.Custom;
using Kalakobana.Infrastructure.Repositories.Animals;
using Kalakobana.Infrastructure.Units;
using MediatR;

namespace Kalakobana.Application.Animals.Commands
{
    public class DeleteAnimalCommandHandler : IRequestHandler<DeleteAnimalCommand, bool>
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAnimalCommandHandler(IAnimalRepository animalRepository, IUnitOfWork unitOfWork)
        {
            _animalRepository = animalRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteAnimalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _animalRepository.DeleteAsync(cancellationToken, request.Name);
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
