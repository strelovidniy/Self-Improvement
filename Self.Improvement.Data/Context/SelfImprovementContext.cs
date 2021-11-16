using Microsoft.EntityFrameworkCore;

namespace Self.Improvement.Data.Context
{
    public class SelfImprovementContext : DbContext
    {
        public SelfImprovementContext(DbContextOptions<SelfImprovementContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
            optionsBuilder.EnableSensitiveDataLogging();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
