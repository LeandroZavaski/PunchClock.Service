using MediatR;
using PunchClock.Service.Persistence.Entities;

namespace PunchClock.Service.Application.Commands.PointRecord
{
    public class RemoveUserByIdCommand : IRequest<UserResponse>
    {
        public string Id { get; set; }

        public RemoveUserByIdCommand(string id)
        {
            Id = id;
        }
    }
}
