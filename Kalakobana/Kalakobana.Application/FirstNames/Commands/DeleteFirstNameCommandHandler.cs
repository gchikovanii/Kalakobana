using Kalakobana.Application.Animals.Commands;
using Kalakobana.Application.Errors.Custom;
using Kalakobana.Infrastructure.Repositories.Animals;
using Kalakobana.Infrastructure.Repositories.FirstNames;
using Kalakobana.Infrastructure.Units;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Application.FirstNames.Commands
{
    public class DeleteFirstNameCommandHandler : IRequestHandler<DeleteFirstNameCommand, bool>
    {
        private readonly IFirstNameRepository _firstNameRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteFirstNameCommandHandler(IFirstNameRepository firstNameRepository, IUnitOfWork unitOfWork)
        {
            _firstNameRepository = firstNameRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteFirstNameCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _firstNameRepository.DeleteAsync(cancellationToken, request.Name);
                var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
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
