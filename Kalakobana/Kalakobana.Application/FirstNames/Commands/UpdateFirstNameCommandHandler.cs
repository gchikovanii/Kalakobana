using Kalakobana.Application.Animals.Commands;
using Kalakobana.Application.Errors.Custom;
using Kalakobana.Infrastructure.Repositories.Animals;
using Kalakobana.Infrastructure.Repositories.FirstNames;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.FirstNames.Commands
{
    public class UpdateFirstNameCommandHandler : IRequestHandler<UpdateFirstNameCommand, bool>
    {
        private readonly IFirstNameRepository _firstNameRepository;

        public UpdateFirstNameCommandHandler(IFirstNameRepository firstNameRepository)
        {
            _firstNameRepository = firstNameRepository;
        }

        public async Task<bool> Handle(UpdateFirstNameCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _firstNameRepository.UpdateAsync(cancellationToken, request.Name, request.NewName).ConfigureAwait(false);

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
