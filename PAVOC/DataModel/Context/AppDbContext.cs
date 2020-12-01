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
        public DbSet<LearnQuestionEntity> LearnQuestions { get; set; }
        public DbSet<LearnQuestionAnswerEntity> LearnQuestionAnswers { get; set; }
        public DbSet<TestLevelEntity> TestLevels { get; set; }
        public DbSet<TestQuestionEntity> TestQuestions { get; set; }
        public DbSet<TestQuestionAnswerEntity> TestQuestionAnswers { get; set; }

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

            // LearnLevel -> LearnQuestion relationship
            modelBuilder.Entity<LearnQuestionEntity>()
                .HasOne(p => p.LearnLevelEntity)
                .WithMany(b => b.LearnQuestions)
                .HasForeignKey(p => p.LearnLevelEntityId);

            // LearnQuestion -> LearnQuestionAnswer relationship
            modelBuilder.Entity<LearnQuestionAnswerEntity>()
                .HasOne(p => p.LearnQuestion)
                .WithMany(b => b.LearnQuestionAnswers)
                .HasForeignKey(p => p.LearnQuestionEntityId);


            // Category -> TestLevel relationship
            modelBuilder.Entity<TestLevelEntity>()
                .HasOne(p => p.Category)
                .WithMany(b => b.TestLevels)
                .HasForeignKey(p => p.CategoryEntityId);

            // TestLevel -> TestQuestion relationship
            modelBuilder.Entity<TestQuestionEntity>()
                .HasOne(p => p.TestLevelEntity)
                .WithMany(b => b.TestQuestions)
                .HasForeignKey(p => p.TestLevelEntityId);

            // TestQuestion -> TestQuestionAnswer relationship
            modelBuilder.Entity<TestQuestionAnswerEntity>()
                .HasOne(p => p.TestQuestion)
                .WithMany(b => b.TestQuestionAnswers)
                .HasForeignKey(p => p.TestQuestionEntityId);
        }
    }
}
