using DelMazo.PointRecord.Service.Application.Helpers;
using DelMazo.PointRecord.Service.Domain.Entities;
using DelMazo.PointRecord.Service.Persistence.Entities;
using DelMazo.PointRecord.Service.Persistence.Interfaces;
using DelMazo.PointRecord.Service.PersistenceDb.Context;
using DelMazo.PointRecord.Service.PersistenceDb.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DelMazo.PointRecord.Service.PersistenceDb.Services
{
    public class Reader : IReader
    {
        private readonly ILogger<Reader> _logger;
        private readonly DataContext _context;
        private readonly AppSettings _appSettings;

        public Reader(ILogger<Reader> logger, DataContext context, IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _context = context;
            _appSettings = appSettings.Value;
        }

        public async Task<UserResponse> GetById(string id)
        {
            _logger.LogInformation("Start get all users from db");

            try
            {
                var response = await _context.GetById<User>(id, ColllectionsEnum.Users.ToString());
                var json = JsonConvert.SerializeObject(response);
                return JsonConvert.DeserializeObject<UserResponse>(json);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failad to get all users", ex.Message);
                return null;
            }
        }

        public async Task<IEnumerable<UserResponse>> GetUserAsync()
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
                _logger.LogError("Failad to get all users", ex.Message);
                return null;
            }
        }

        public async Task<AuthResponse> GetAuthLogin(Auth login)
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
                _logger.LogError("Failad to get auth users", ex.Message);
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
