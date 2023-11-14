using Kalakobana.Application.Animals.Commands;
using Kalakobana.Application.Errors.Custom;
using Kalakobana.Infrastructure.Repositories.Animals;
using Kalakobana.Infrastructure.Repositories.LastNames;
using Kalakobana.Infrastructure.Units;
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
        private readonly IUnitOfWork _unitOfWork;
        public DeleteLastNameCommandHandler(ILastNameRepository lastNameRepository, IUnitOfWork unitOfWork)
        {
            _lastNameRepository = lastNameRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteLastNameCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _lastNameRepository.DeleteAsync(cancellationToken, request.Name);
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
