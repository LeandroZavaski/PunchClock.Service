using DelMazo.PointRecord.Service.Persistence.Entities;
using MediatR;
using System.Collections.Generic;

namespace DelMazo.PointRecord.Service.Application.Querys.PointRecord
{
    public class ReadRolesQuery : IRequest<IEnumerable<RoleResponse>>
    {
    }
}
