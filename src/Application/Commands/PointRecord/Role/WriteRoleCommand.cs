using MediatR;
using PunchClock.Service.Persistence.Entities;

namespace PunchClock.Service.Application.Commands.PointRecord.Role
{
    public class WriteRoleCommand : IRequest<RoleResponse>
    {
        public Domain.Entities.Role Role { get; set; }

        public WriteRoleCommand(Domain.Entities.Role role)
        {
            Role = role;
        }
    }
}
