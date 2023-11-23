using Kalakobana.Infrastructure.Errors;
using Kalakobana.Infrastructure.Localizations;
using Kalakobana.Infrastructure.Repositories.Animals;
using Kalakobana.Infrastructure.Units;
using MediatR;


namespace Kalakobana.Application.Animals.Commands
{
    public class UpdateAnimalCommandHandler : IRequestHandler<UpdateAnimalCommand, bool>
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateAnimalCommandHandler(IAnimalRepository animalRepository, IUnitOfWork unitOfWork)
        {
            _animalRepository = animalRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateAnimalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _animalRepository.UpdateAsync(cancellationToken, request.Name, request.NewName,request.AnimalType).ConfigureAwait(false);
                var result = await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                if (result == false)
                    throw new NotFoundException(ErrorMessages.NotFound);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
