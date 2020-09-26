using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PunchClock.Service.Domain.Entities;
using PunchClock.Service.Persistence.Entities;
using PunchClock.Service.Persistence.Interfaces.Readers;
using PunchClock.Service.PersistenceDb.Context;
using PunchClock.Service.PersistenceDb.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PunchClock.Service.PersistenceDb.Services.Readers
{
    public class ReadVacation : IReadVacation
    {
        private readonly ILogger<ReadVacation> _logger;
        private readonly DataContext _context;
        private readonly AppSettings _appSettings;

        public ReadVacation(ILogger<ReadVacation> logger, DataContext context, IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _context = context;
            _appSettings = appSettings.Value;
        }

        public async Task<IEnumerable<VacationResponse>> GetVacationsAsync()
        {
            _logger.LogInformation("Start get vacations from db");

            try
            {
                var response = await _context.GetAll<Vacation>(ColllectionsEnum.Vacations.ToString());
                var list = (response.Where(item => item.Active)).ToList();
                var json = JsonConvert.SerializeObject(list);

                return JsonConvert.DeserializeObject<IEnumerable<VacationResponse>>(json);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get all vacations", ex.Message);
                return null;
            }
        }
    }
}
