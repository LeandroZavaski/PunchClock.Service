using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PunchClock.Service.Application.Helpers;
using PunchClock.Service.Domain.Entities;
using PunchClock.Service.Persistence.Entities;
using PunchClock.Service.Persistence.Interfaces.Readers;
using PunchClock.Service.PersistenceDb.Context;
using PunchClock.Service.PersistenceDb.Enums;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PunchClock.Service.PersistenceDb.Services.Readers
{
    public class ReadAuth : IReadAuth
    {
        private readonly ILogger<ReadAuth> _logger;
        private readonly DataContext _context;
        private readonly AppSettings _appSettings;

        public ReadAuth(ILogger<ReadAuth> logger, DataContext context, IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _context = context;
            _appSettings = appSettings.Value;
        }

        public async Task<AuthResponse> GetAuthLoginAsync(Auth login)
        {
            _logger.LogInformation("Start get auth users from db");

            try
            {
                var response = await _context.GetAuth<Auth>(login.Document, ColllectionsEnum.Auths.ToString());

                if (response is null)
                    return response;

                if (!PointRecordHashPass.Decrypt(response.Password).Equals(login.Password))
                    return null;

                if (response.FirstAccess)
                    return response;

                var token = GetToken(response);
                response.Token = token;

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get auth users", ex.Message);
                return null;
            }
        }

        private string GetToken(Auth response)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, response.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
