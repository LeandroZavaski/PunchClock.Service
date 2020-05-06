using DelMazo.PointRecord.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DelMazo.PointRecord.Service.PersistenceDb.Context
{
    public class PointRecordContext : DbContext
    {
        public PointRecordContext(DbContextOptions<PointRecordContext> options) : base(options) { }
        public DbSet<Login> Login { get; set; }
        public DbSet<PunchClock> PunchClock { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { }
    }
}
