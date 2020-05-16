using DelMazo.PointRecord.Service.Application.Commands.PointRecord;
using DelMazo.PointRecord.Service.Persistence.Entities;
using DelMazo.PointRecord.Service.Persistence.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DelMazo.PointRecord.Service.Application.CommandsHandlers.PointRecord.Users
{
    public class RemoveUserByIdHandler : IRequestHandler<RemoveUserByIdCommand, UserResponse>
    {
        private readonly IRemove _removeRepository;

        public RemoveUserByIdHandler(IRemove removeRepository)
        {
            _removeRepository = removeRepository;
        }

        public async Task<UserResponse> Handle(RemoveUserByIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _removeRepository.RemoveUserByIdAsync(request.Id);
            return response;
        }
    }
}
