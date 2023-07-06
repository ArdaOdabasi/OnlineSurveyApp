using Microsoft.EntityFrameworkCore;
using OnlineSurveyApp.Entities;

namespace OnlineSurveyApp.Infrastructure.Data
{
    public class OnlineSurveyDbContext : DbContext
    {
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            RulesForSurveyProperties(modelBuilder);

            RulesForQuestionProperties(modelBuilder);

            RulesForOptionProperties(modelBuilder);

            RulesForUserProperties(modelBuilder);

            modelBuilder.Entity<Survey>().HasOne(s => s.Constituent)
                                         .WithMany(c => c.Surveys)
                                         .HasForeignKey(s => s.ConstituentId)
                                         .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Question>().HasOne(q => q.Survey)
                                           .WithMany(s => s.Questions)
                                           .HasForeignKey(q => q.SurveyId)
                                           .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Option>().HasOne(o => o.Question)
                                         .WithMany(q => q.Options)
                                         .HasForeignKey(o => o.QuestionId)
                                         .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Answer>().HasOne(a => a.Redditive)
                                         .WithMany(r => r.Answers)
                                         .HasForeignKey(a => a.RedditiveId)
                                         .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Answer>().HasOne(a => a.Survey)
                                         .WithMany(s => s.Answers)
                                         .HasForeignKey(a => a.SurveyId)
                                         .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Answer>().HasOne(a => a.Question)
                                         .WithMany(q => q.Answers)
                                         .HasForeignKey(a => a.QuestionId)
                                         .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Answer>().HasOne(a => a.Option)
                                         .WithMany(o => o.Answers)
                                         .HasForeignKey(a => a.OptionId)
                                         .OnDelete(DeleteBehavior.SetNull);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=OnlineSurvey;Integrated Security=True");
        }

        private static void RulesForSurveyProperties(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Survey>().Property(s => s.Title)
                                         .IsRequired()
                                         .HasMaxLength(250);

            modelBuilder.Entity<Survey>().Property(s => s.Explanation)
                                         .IsRequired()
                                         .HasMaxLength(300);

            modelBuilder.Entity<Survey>().Property(s => s.Active)
                                         .IsRequired();
        }

        private static void RulesForQuestionProperties(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>().Property(q => q.Text)
                                           .IsRequired()
                                           .HasMaxLength(250);          
        }

        private static void RulesForOptionProperties(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Option>().Property(o => o.Text)
                                         .IsRequired()
                                         .HasMaxLength(250);
        }

        private void RulesForUserProperties(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(u => u.FirstName)
                                       .IsRequired()
                                       .HasMaxLength(100);

            modelBuilder.Entity<User>().Property(u => u.LastName)
                                       .IsRequired()
                                       .HasMaxLength(100);

            modelBuilder.Entity<User>().Property(u => u.UserName)
                                       .IsRequired()
                                       .HasMaxLength(100);

            modelBuilder.Entity<User>().Property(u => u.Password)
                                       .IsRequired()
                                       .HasMaxLength(100);

            modelBuilder.Entity<User>().Property(u => u.Role)
                                       .IsRequired()
                                       .HasMaxLength(100);
        }
    }
}
