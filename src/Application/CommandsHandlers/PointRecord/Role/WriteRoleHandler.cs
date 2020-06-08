using DelMazo.PointRecord.Service.Application.Commands.PointRecord.Role;
using DelMazo.PointRecord.Service.Persistence.Entities;
using DelMazo.PointRecord.Service.Persistence.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelMazo.PointRecord.Service.Application.CommandsHandlers.PointRecord.Role
{
    public class WriteRoleHandler : IRequestHandler<WriteRoleCommand, RoleResponse>
    {
        private readonly IWrite _writeRepository;

        public WriteRoleHandler(IWrite writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<RoleResponse> Handle(WriteRoleCommand request, CancellationToken cancellationToken)
        {
            return await _writeRepository.WriteRoleAsync(request.Role);
        }
    }
}
