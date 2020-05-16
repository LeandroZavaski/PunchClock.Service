using DelMazo.PointRecord.Service.Domain.Entities;
using DelMazo.PointRecord.Service.Persistence.Entities;
using DelMazo.PointRecord.Service.Persistence.Interfaces;
using DelMazo.PointRecord.Service.PersistenceDb.Context;
using DelMazo.PointRecord.Service.PersistenceDb.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace DelMazo.PointRecord.Service.PersistenceDb.Services
{
    public class Remove : IRemove
    {
        private readonly ILogger<Remove> _logger;
        private readonly DataContext _context;
        private readonly AppSettings _appSettings;

        public Remove(ILogger<Remove> logger, DataContext context, IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _context = context;
            _appSettings = appSettings.Value;
        }

        public async Task<UserResponse> RemoveUserByIdAsync(string id)
        {
            _logger.LogInformation("Start get all users from db");

            try
            {
                await _context.Remove<Auth>(id, ColllectionsEnum.Auths.ToString());

                var response = await _context.Remove<User>(id, ColllectionsEnum.Users.ToString());
                var json = JsonConvert.SerializeObject(response);

                return JsonConvert.DeserializeObject<UserResponse>(json);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failad to get all users", ex.Message);
                return null;
            }
        }
    }
}
