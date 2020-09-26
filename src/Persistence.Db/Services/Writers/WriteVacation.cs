using Microsoft.Extensions.Logging;
using PunchClock.Service.Domain.Entities;
using PunchClock.Service.Persistence.Entities;
using PunchClock.Service.Persistence.Interfaces.Writers;
using PunchClock.Service.PersistenceDb.Context;
using PunchClock.Service.PersistenceDb.Enums;
using System;
using System.Threading.Tasks;

namespace PunchClock.Service.PersistenceDb.Services.Writers
{
    public class WriteVacation : IWriteVacation
    {
        private readonly ILogger<WriteVacation> _logger;
        private readonly DataContext _context;

        public WriteVacation(ILogger<WriteVacation> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<VacationResponse> WriteVacationAsync(Vacation vacation)
        {
            _logger.LogInformation("Start write vacation");

            try
            {
                var response = await _context.Add(vacation, vacation.Id, ColllectionsEnum.Vacations.ToString());
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, $"Not was possible load data vacationId: {vacation.Id}");
                return null;
            }
        }

        public async Task<VacationResponse> WriteVacationUpdateAsync(Vacation vacation, string id)
        {
            _logger.LogInformation("Start update vacation");

            try
            {
                //Update user
                vacation.Id = id;
                var response = await _context.Update(vacation, id, ColllectionsEnum.Vacations.ToString());
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, $"Not was possible update data vacationId: {id}");
                return null;
            }
        }
    }
}
