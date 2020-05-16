using DelMazo.PointRecord.Service.Persistence.Entities;
using MediatR;

namespace DelMazo.PointRecord.Service.Application.Querys.PointRecord
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
