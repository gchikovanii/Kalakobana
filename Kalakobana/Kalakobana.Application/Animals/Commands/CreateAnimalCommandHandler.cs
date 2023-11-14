using Kalakobana.Domain.Animals;
using Kalakobana.Infrastructure.Repositories.Animals;
using Kalakobana.Infrastructure.Units;
using Mapster;
using MediatR;


namespace Kalakobana.Application.Animals.Commands
{
    internal class CreateAnimalCommandHandler : IRequestHandler<CreateAnimalCommand, bool>
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateAnimalCommandHandler(IAnimalRepository animalRepository, IUnitOfWork unitOfWork)
        {
            _animalRepository = animalRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(CreateAnimalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _animalRepository.CreateAsync(cancellationToken, request.Adapt<Animal>()).ConfigureAwait(false);
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
