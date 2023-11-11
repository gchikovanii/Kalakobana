using Kalakobana.Domain.Animals;
using Kalakobana.Infrastructure.Repositories.Animals;
using Mapster;
using MediatR;


namespace Kalakobana.Application.Animals.Commands
{
    internal class CreateAnimalCommandHandler : IRequestHandler<CreateAnimalCommand, int>
    {
        private readonly IAnimalRepository _animalRepository;

        public CreateAnimalCommandHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }
        public async Task<int> Handle(CreateAnimalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _animalRepository.CreateAsync(cancellationToken, request.Adapt<Animal>()).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
