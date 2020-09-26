using MediatR;
using PunchClock.Service.Persistence.Entities;

namespace PunchClock.Service.Application.Commands.PointRecord.Role
{
    public class RemoveRoleByIdCommand : IRequest<RoleResponse>
    {
        public string Id { get; set; }

        public RemoveRoleByIdCommand(string id)
        {
            Id = id;
        }
    }
}
