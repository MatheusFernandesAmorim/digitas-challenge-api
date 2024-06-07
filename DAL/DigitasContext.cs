using DigitasChallenge.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitasChallenge.DAL
{
    public class DigitasContext : DbContext
    {
        public DigitasContext(DbContextOptions<DigitasContext> options) : base(options)
        {
        }

        public DbSet<Tasks> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DigitasContext).Assembly);            
        }
    }
}