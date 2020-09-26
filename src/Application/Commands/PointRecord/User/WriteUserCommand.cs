using MediatR;
using PunchClock.Service.Domain.Entities;
using PunchClock.Service.Persistence.Entities;

namespace PunchClock.Service.Application.Commands.PointRecord
{
    public class WriteUserCommand : IRequest<UserResponse>
    {
        public User User { get; set; }

        public WriteUserCommand(User user)
        {
            User = user;
        }
    }
}
