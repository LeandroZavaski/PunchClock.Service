using MediatR;
using PunchClock.Service.Persistence.Entities;
using System.Collections.Generic;

namespace PunchClock.Service.Application.Querys.PointRecord
{
    public class ReadUsersQuery : IRequest<IEnumerable<UserResponse>>
    {
    }
}
