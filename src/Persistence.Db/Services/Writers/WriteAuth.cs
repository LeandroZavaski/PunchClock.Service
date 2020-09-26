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
    public class WriteAuth : IWriteAuth
    {
        private readonly ILogger<WriteAuth> _logger;
        private readonly DataContext _context;

        public WriteAuth(ILogger<WriteAuth> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<AuthResponse> WriteAuthReset(Auth reset)
        {
            _logger.LogInformation("Start reset password from document: ", reset.Document);

            try
            {
                var auth = await _context.GetAuth<Auth>(reset.Document, ColllectionsEnum.Auths.ToString());

                if (auth is null)
                    return auth;

                reset.Id = auth.Id;
                var response = await _context.Update(reset, auth.Id, ColllectionsEnum.Auths.ToString());

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, $"Not was possible reset password from document: {reset.Document}");
                return null;
            }
        }
    }
}
