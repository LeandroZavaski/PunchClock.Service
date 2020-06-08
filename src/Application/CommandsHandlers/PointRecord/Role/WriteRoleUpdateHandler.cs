using DelMazo.PointRecord.Service.Application.Commands.PointRecord.Role;
using DelMazo.PointRecord.Service.Persistence.Entities;
using DelMazo.PointRecord.Service.Persistence.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DelMazo.PointRecord.Service.Application.CommandsHandlers.PointRecord.Role
{
    public class WriteRoleUpdateHandler : IRequestHandler<WriteRoleUpdateCommand, RoleResponse>
    {
        private readonly IWrite _writeRepository;

        public WriteRoleUpdateHandler(IWrite writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<RoleResponse> Handle(WriteRoleUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _writeRepository.WriteRoleUpdateAsync(request.Role, request.Id);
        }
    }
}
