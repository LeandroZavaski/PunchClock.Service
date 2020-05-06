using DelMazo.PointRecord.Service.Domain.Entities;
using DelMazo.PointRecord.Service.Persistence.Entities;
using MediatR;

namespace DelMazo.PointRecord.Service.Application.Querys.PointRecord
{
    public class ReadUserLoginQuery : IRequest<LoginResponse>
    {
        public Login Login { get; set; }

        public ReadUserLoginQuery(Login login)
        {
            Login = login;
        }
    }
}
