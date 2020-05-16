using DelMazo.PointRecord.Service.Domain.Entities;
using DelMazo.PointRecord.Service.Persistence.Entities;
using DelMazo.PointRecord.Service.Persistence.Interfaces;
using DelMazo.PointRecord.Service.PersistenceDb.Context;
using DelMazo.PointRecord.Service.PersistenceDb.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

        public Task<AuthResponse> GetAuthLogin(Auth login)
        {
            throw new NotImplementedException();
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

        //public async Task<AuthResponse> GetAuthLogin(Auth login)
        //{
        //    var response = _context.Auth.Where(w => w.Document.Equals(login.Document) && w.Password.Equals(login.Password)).FirstOrDefault();

        //    if (response is null)
        //        return response;

        //    var token = await GetToken(response);
        //    response.Token = token;

        //    return response;
        //}

        //public async Task<User> GetById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //private async Task<string> GetToken(Auth response)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
        //            new Claim(ClaimTypes.Name, response.Id.ToString())
        //        }),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    var tokenString = tokenHandler.WriteToken(token);

        //    return tokenString;
        //}
    }
}
