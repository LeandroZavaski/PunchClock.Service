using DelMazo.PointRecord.Service.Domain.Entities;
using DelMazo.PointRecord.Service.Persistence.Entities;
using MediatR;

namespace DelMazo.PointRecord.Service.Application.Querys.PointRecord
{
    public class GetUserLoginQuery : IRequest<LoginResponse>
    {
        public Login Login { get; set; }

        public GetUserLoginQuery(Login login)
        {
            Login = login;
        }
    }
}
