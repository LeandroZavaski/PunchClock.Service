using MediatR;
using PunchClock.Service.Persistence.Entities;

namespace PunchClock.Service.Application.Commands.PointRecord.Role
{
    public class WriteRoleUpdateCommand : IRequest<RoleResponse>
    {
        public string Id { get; set; }
        public Domain.Entities.Role Role { get; set; }

        public WriteRoleUpdateCommand(string id, Domain.Entities.Role role)
        {
            Id = id;
            Role = role;
        }
    }
}
