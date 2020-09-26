using MediatR;
using PunchClock.Service.Persistence.Entities;

namespace PunchClock.Service.Application.Querys.PointRecord
{
    public class ReadUserByDocumentQuery : IRequest<UserResponse>
    {
        public string Document { get; set; }

        public ReadUserByDocumentQuery(string document)
        {
            Document = document;
        }
    }
}
