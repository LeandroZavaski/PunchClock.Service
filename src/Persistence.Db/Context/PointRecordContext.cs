using DelMazo.PointRecord.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DelMazo.PointRecord.Service.PersistenceDb.Context
{
    public class PointRecordContext : DbContext
    {
        public PointRecordContext(DbContextOptions<PointRecordContext> options) : base(options) { }
        public DbSet<Login> Login { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { }
    }
}
