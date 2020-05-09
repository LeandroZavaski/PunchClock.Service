using System;
using System.Collections.Generic;

namespace DelMazo.PointRecord.Service.Domain.Entities
{
    public partial class Address
    {
        public int Id { get; set; }
        public string Addres { get; set; }
        public string PostalCode { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Complement { get; set; }
    }
}
