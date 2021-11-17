using Microsoft.EntityFrameworkCore;
using Self.Improvement.Data.Entities;
using Self.Improvement.Data.Enums;

namespace Self.Improvement.Data.Context
{
    public class SelfImprovementContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Goal> Goals { get; set; }

        public SelfImprovementContext(DbContextOptions<SelfImprovementContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
            optionsBuilder.EnableSensitiveDataLogging();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Date)
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("GETUTCDATE()");

                entity.Property(e => e.Status)
                    .ValueGeneratedOnAdd()
                    .HasDefaultValue(MessageStatus.Unread);
            });

            modelBuilder.Entity<Goal>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<User>()
                .HasMany(e => e.Messages)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .HasPrincipalKey(e => e.Id);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Goals)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .HasPrincipalKey(e => e.Id);
        }
    }
}
