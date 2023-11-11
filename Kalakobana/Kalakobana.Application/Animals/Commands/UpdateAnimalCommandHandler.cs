using Kalakobana.Application.Errors.Custom;
using Kalakobana.Infrastructure.Repositories.Animals;
using MediatR;


namespace Kalakobana.Application.Animals.Commands
{
    public class UpdateAnimalCommandHandler : IRequestHandler<UpdateAnimalCommand, bool>
    {
        private readonly IAnimalRepository _animalRepository;

        public UpdateAnimalCommandHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<bool> Handle(UpdateAnimalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _animalRepository.UpdateAsync(cancellationToken, request.Name, request.NewName).ConfigureAwait(false);

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
