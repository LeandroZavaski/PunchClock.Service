using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PunchClock.Service.Domain.Entities;
using PunchClock.Service.Persistence.Entities;
using PunchClock.Service.Persistence.Interfaces.Removes;
using PunchClock.Service.PersistenceDb.Context;
using PunchClock.Service.PersistenceDb.Enums;
using System;
using System.Threading.Tasks;

namespace PunchClock.Service.PersistenceDb.Services.Removes
{
    public class RemoveVacation : IRemoveVacation
    {
        private readonly ILogger<RemoveVacation> _logger;
        private readonly DataContext _context;
        private readonly AppSettings _appSettings;

        public RemoveVacation(ILogger<RemoveVacation> logger, DataContext context, IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _context = context;
            _appSettings = appSettings.Value;
        }

        public async Task<VacationResponse> RemoveVacationByIdAsync(string id)
        {
            _logger.LogInformation("Start remove vacation by id from db");

            try
            {
                var response = await _context.Remove<Vacation>(id, ColllectionsEnum.Vacations.ToString());
                var json = JsonConvert.SerializeObject(response);

                return JsonConvert.DeserializeObject<VacationResponse>(json);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed remove role by id from db", ex.Message);
                return null;
            }
        }
    }
}
