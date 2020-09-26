using MediatR;
using PunchClock.Service.Domain.Entities;
using PunchClock.Service.Persistence.Entities;

namespace PunchClock.Service.Application.Querys.PointRecord
{
    public class ReadAuthQuery : IRequest<AuthResponse>
    {
        public Auth Login { get; set; }

        public ReadAuthQuery(Auth login)
        {
            Login = login;
        }
    }
}
