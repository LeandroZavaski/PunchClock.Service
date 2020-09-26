using MediatR;
using PunchClock.Service.Persistence.Entities;

namespace PunchClock.Service.Application.Querys.PointRecord
{
    public class ReadUserByIdQuery : IRequest<UserResponse>
    {
        public string Id { get; set; }

        public ReadUserByIdQuery(string id)
        {
            Id = id;
        }
    }
}
