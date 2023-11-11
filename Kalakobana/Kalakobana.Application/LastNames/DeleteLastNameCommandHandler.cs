using Kalakobana.Application.Animals.Commands;
using Kalakobana.Application.Errors.Custom;
using Kalakobana.Infrastructure.Repositories.Animals;
using Kalakobana.Infrastructure.Repositories.LastNames;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.LastNames
{
    public class DeleteLastNameCommandHandler : IRequestHandler<DeleteLastNameCommand, bool>
    {
        private readonly ILastNameRepository _lastNameRepository;

        public DeleteLastNameCommandHandler(ILastNameRepository lastNameRepository)
        {
            _lastNameRepository = lastNameRepository;
        }

        public async Task<bool> Handle(DeleteLastNameCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _lastNameRepository.DeleteAsync(cancellationToken, request.Name);
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
