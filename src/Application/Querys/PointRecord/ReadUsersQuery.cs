using DelMazo.PointRecord.Service.Persistence.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DelMazo.PointRecord.Service.Application.Querys.PointRecord
{
    public class ReadUsersQuery : IRequest<IEnumerable<UserResponse>>
    {
    }
}
