using System;
using System.Collections.Generic;
using System.Text;

namespace DelMazo.PointRecord.Service.Persistence.Entities
{
    public class LoginResponse
    {
        public int Id { get; set; }
        public string Document { get; set; }
        public string Password { get; set; }
    }
}
