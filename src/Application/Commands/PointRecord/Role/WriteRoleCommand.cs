using DelMazo.PointRecord.Service.Persistence.Entities;
using MediatR;

namespace DelMazo.PointRecord.Service.Application.Commands.PointRecord.Role
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
