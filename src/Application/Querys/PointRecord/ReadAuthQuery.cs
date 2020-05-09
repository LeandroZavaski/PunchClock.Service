using DelMazo.PointRecord.Service.Domain.Entities;
using DelMazo.PointRecord.Service.Persistence.Entities;
using MediatR;

namespace DelMazo.PointRecord.Service.Application.Querys.PointRecord
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
