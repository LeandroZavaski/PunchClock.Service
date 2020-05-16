using DelMazo.PointRecord.Service.Domain.Entities;
using DelMazo.PointRecord.Service.Persistence.Entities;
using MediatR;

namespace DelMazo.PointRecord.Service.Application.Commands.PointRecord
{
    public class WriteAuthResetCommand : IRequest<AuthResponse>
    {
        public Auth Auth { get; set; }
        public WriteAuthResetCommand(Auth auth)
        {
            Auth = auth;
        }
    }
}
