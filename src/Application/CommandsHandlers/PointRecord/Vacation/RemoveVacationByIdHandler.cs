using MediatR;
using PunchClock.Service.Application.Commands.PointRecord.Vacation;
using PunchClock.Service.Persistence.Entities;
using PunchClock.Service.Persistence.Interfaces.Removes;
using System.Threading;
using System.Threading.Tasks;

namespace PunchClock.Service.Application.CommandsHandlers.PointRecord.Vacation
{
    public class RemoveVacationByIdHandler : IRequestHandler<RemoveVacationByIdCommand, VacationResponse>
    {
        private readonly IRemoveVacation _removeRepository;

        public RemoveVacationByIdHandler(IRemoveVacation removeRepository)
        {
            _removeRepository = removeRepository;
        }

        public async Task<VacationResponse> Handle(RemoveVacationByIdCommand request, CancellationToken cancellationToken)
        {
            return await _removeRepository.RemoveVacationByIdAsync(request.Id);
        }
    }
}
