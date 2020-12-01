using System;
using Microsoft.EntityFrameworkCore;
using PAVOC.DataModel.Models;

namespace PAVOC.DataModel.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<FeedbackEntity> Feedbacks { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<LearnLevelEntity> LearnLevels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=pavoc.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User -> Feedback relationship
            modelBuilder.Entity<FeedbackEntity>()
                .HasOne(p => p.User)
                .WithMany(b => b.Feedbacks)
                .HasForeignKey(p => p.UserEntityId);

            // Category -> LearnLevel relationship
            modelBuilder.Entity<LearnLevelEntity>()
                .HasOne(p => p.Category)
                .WithMany(b => b.LearnLevels)
                .HasForeignKey(p => p.CategoryEntityId);

        }
    }
}
