using AutoMapper;
using DelMazo.PointRecord.Service.Domain.Entities;
using DelMazo.PointRecord.Service.Persistence.Entities;
using DelMazo.PointRecord.Service.Persistence.Interfaces;
using DelMazo.PointRecord.Service.PersistenceDb.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelMazo.PointRecord.Service.PersistenceDb.Services
{
    public class Reader : IReader
    {
        private readonly PointRecordContext _context;

        public Reader(PointRecordContext context)
        {
            _context = context;
        }

        public async Task<LoginResponse> GetUserLogin(Login login)
        {
            var response = _context.Login.Where(w => w.Document.Equals(login.Document) && w.Password.Equals(login.Password)).FirstOrDefault();
            return response;

        }
    }
}
