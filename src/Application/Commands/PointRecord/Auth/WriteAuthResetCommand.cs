using PunchClock.Service.Persistence.Entities;
using MediatR;

namespace PunchClock.Service.Application.Commands.PointRecord.Auth
{
    public class WriteAuthResetCommand : IRequest<AuthResponse>
    {
        public Domain.Entities.Auth Auth { get; set; }
        public WriteAuthResetCommand(Domain.Entities.Auth auth)
        {
            Auth = auth;
        }
    }
}
