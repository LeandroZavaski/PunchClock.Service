using DelMazo.PointRecord.Service.Domain.Entities;
using DelMazo.PointRecord.Service.Persistence.Entities;
using MediatR;

namespace DelMazo.PointRecord.Service.Application.Commands.PointRecord
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
