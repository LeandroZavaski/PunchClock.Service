using DelMazo.PointRecord.Service.Application.Commands.PointRecord.Role;
using DelMazo.PointRecord.Service.Persistence.Entities;
using DelMazo.PointRecord.Service.Persistence.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DelMazo.PointRecord.Service.Application.CommandsHandlers.PointRecord.Role
{
    public class RemoveRoleByIdHandler : IRequestHandler<RemoveRoleByIdCommand, RoleResponse>
    {
        private readonly IRemove _removeRepository;

        public RemoveRoleByIdHandler(IRemove removeRepository)
        {
            _removeRepository = removeRepository;
        }

        public async Task<RoleResponse> Handle(RemoveRoleByIdCommand request, CancellationToken cancellationToken)
        {
            return await _removeRepository.RemoveRoleByIdAsync(request.Id);
        }
    }
}
