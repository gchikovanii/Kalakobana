using Kalakobana.Application.Errors.Custom;
using Kalakobana.Infrastructure.Repositories.Animals;
using MediatR;

namespace Kalakobana.Application.Animals.Commands
{
    public class DeleteAnimalCommandHandler : IRequestHandler<DeleteAnimalCommand, bool>
    {
        private readonly IAnimalRepository _animalRepository;

        public DeleteAnimalCommandHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<bool> Handle(DeleteAnimalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _animalRepository.DeleteAsync(cancellationToken, request.Name);
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
