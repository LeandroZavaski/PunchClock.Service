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
    public class ReadUser : IReadUser
    {
        private readonly ILogger<ReadUser> _logger;
        private readonly DataContext _context;
        private readonly AppSettings _appSettings;

        public ReadUser(ILogger<ReadUser> logger, DataContext context, IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _context = context;
            _appSettings = appSettings.Value;
        }

        public async Task<UserResponse> GetUserByIdAsync(string id)
        {
            _logger.LogInformation("Start get user by id from db");

            try
            {
                var response = await _context.GetById<User>(id, ColllectionsEnum.Users.ToString());
                var json = JsonConvert.SerializeObject(response);
                return JsonConvert.DeserializeObject<UserResponse>(json);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get user by id - Id: {id}, Message: {Message}", id, ex.Message);
                return null;
            }
        }

        public async Task<IEnumerable<UserResponse>> GetUsersAsync()
        {
            _logger.LogInformation("Start get all users from db");

            try
            {
                var response = await _context.GetAll<User>(ColllectionsEnum.Users.ToString());
                var json = JsonConvert.SerializeObject(response);
                return JsonConvert.DeserializeObject<IEnumerable<UserResponse>>(json);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get all users", ex.Message);
                return null;
            }
        }

        public async Task<UserResponse> GetUserByDocumentAsync(string document)
        {
            _logger.LogInformation("Start get user by document number from db");

            try
            {
                var response = await _context.GetAll<User>(ColllectionsEnum.Users.ToString());
                var user = response.FirstOrDefault(f => f.Documents.Select(s => s.Number.Equals(document)).FirstOrDefault());
                var json = JsonConvert.SerializeObject(user);
                return JsonConvert.DeserializeObject<UserResponse>(json);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get user by document - Document: {document}, Message: {Message}", document, ex.Message);
                return null;
            }
        }
    }
}
