using MediatR;
using PunchClock.Service.Application.Commands.PointRecord.Role;
using PunchClock.Service.Persistence.Entities;
using PunchClock.Service.Persistence.Interfaces.Removes;
using System.Threading;
using System.Threading.Tasks;

namespace PunchClock.Service.Application.CommandsHandlers.PointRecord.Role
{
    public class RemoveRoleByIdHandler : IRequestHandler<RemoveRoleByIdCommand, RoleResponse>
    {
        private readonly IRemoveRole _removeRepository;

        public RemoveRoleByIdHandler(IRemoveRole removeRepository)
        {
            _removeRepository = removeRepository;
        }

        public async Task<RoleResponse> Handle(RemoveRoleByIdCommand request, CancellationToken cancellationToken)
        {
            return await _removeRepository.RemoveRoleByIdAsync(request.Id);
        }
    }
}
