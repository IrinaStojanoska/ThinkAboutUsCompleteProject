using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ThinkAboutUs.API.Data.Entities;

namespace ThinkAboutUs.API.Data.Context
{
    public class ThinkAboutUsContext : DbContext
    {
        public ThinkAboutUsContext(DbContextOptions<ThinkAboutUsContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<DogEntity> Dogs { get; set; }

        public DbSet<ReportEntity> Reports { get; set; }

        public DbSet<SizeEntity> Sizes { get; set; }
    }
}
