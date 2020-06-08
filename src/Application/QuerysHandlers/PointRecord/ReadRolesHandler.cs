using DelMazo.PointRecord.Service.Application.Querys.PointRecord;
using DelMazo.PointRecord.Service.Persistence.Entities;
using DelMazo.PointRecord.Service.Persistence.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DelMazo.PointRecord.Service.Application.QuerysHandlers.PointRecord
{
    public class ReadRolesHandler : IRequestHandler<ReadRolesQuery, IEnumerable<RoleResponse>>
    {
        private readonly IReader _readRepository;

        public ReadRolesHandler(IReader readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<IEnumerable<RoleResponse>> Handle(ReadRolesQuery request, CancellationToken cancellationToken)
        {
            return await _readRepository.GetRolesAsync();
        }
    }
}
