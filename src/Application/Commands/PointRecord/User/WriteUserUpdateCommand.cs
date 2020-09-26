using MediatR;
using PunchClock.Service.Domain.Entities;
using PunchClock.Service.Persistence.Entities;

namespace PunchClock.Service.Application.Commands.PointRecord
{
    public class WriteUserUpdateCommand : IRequest<UserResponse>
    {
        public string Id { get; set; }
        public User User { get; set; }

        public WriteUserUpdateCommand(User user, string id)
        {
            User = user;
            Id = id;
        }
    }
}
