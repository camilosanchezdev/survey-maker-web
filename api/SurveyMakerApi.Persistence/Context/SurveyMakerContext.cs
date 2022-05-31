using Microsoft.EntityFrameworkCore;
using SurveyMakerApi.Persistence.Models;

namespace SurveyMakerApi.Persistence.Context
{
    public class SurveyMakerContext : DbContext
    {
        public SurveyMakerContext(DbContextOptions<SurveyMakerContext> options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<Survey> Survey { get; set; }
        public DbSet<SurveyStatus> SurveyStatuses { get; set; }
        public DbSet<SurveyTag> SurveyTags { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<ResponseQuestion> ResponseQuestions { get; set; }
        public DbSet<ResponseAnswer> ResponseAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Survey>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");
                entity.ToTable("surveys");
                entity.Property(e => e.Id).HasColumnName("survey_id");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at").HasDefaultValue(DateTime.Now);
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.DisabledAt).HasColumnName("disabled_at");
                entity.Property(e => e.EndsAt).HasColumnName("ends_at");
                entity.Property(e => e.Link).HasColumnName("link");
                entity.Property(e => e.Title).HasColumnName("title");
                entity.HasIndex(e => e.Id, "fk_survey_survey_statuses_idx");
                entity.Property(e => e.SurveyStatusId).HasColumnName("survey_status_id");
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");

                entity.HasIndex(e => e.Id, "fk_survey_users_idx");
                entity.Property(e => e.CreatedBy).HasColumnName("user_id");

                // Relationships

                entity.HasOne(e => e.SurveyStatus)
                .WithMany(p => p.Surveys)
                .HasForeignKey(d => d.SurveyStatusId)
                .HasConstraintName("fk_survey_statuses");

                entity.HasOne(e => e.User)
                .WithMany(p => p.Surveys)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("fk_surveys_users");

                entity.HasMany(s => s.SurveyTags)
                .WithMany(c => c.Surveys)
                .UsingEntity(j => j.ToTable("surveys_tags"));

                entity.HasMany(s => s.Questions)
                .WithOne(c => c.Survey);
               

            });
            modelBuilder.Entity<SurveyStatus>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");
                entity.ToTable("survey_statuses");
                entity.Property(e => e.Id).HasColumnName("status_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
                entity.HasData(
                    new SurveyStatus { Id = 1, Name = "Active"},
                    new SurveyStatus { Id = 2, Name = "Draft" },
                    new SurveyStatus { Id = 3, Name = "Completed" }
                    );
            });
            modelBuilder.Entity<SurveyTag>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");
                entity.ToTable("tags");
                entity.Property(e => e.Id).HasColumnName("tag_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
                entity.HasData(
                    new SurveyTag { Id = 1, Name = "Sports" },
                    new SurveyTag { Id = 2, Name = "Basketball" },
                    new SurveyTag { Id = 3, Name = "Education" },
                    new SurveyTag { Id = 4, Name = "Politics" }
                    );
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");
                entity.ToTable("users");
                entity.Property(e => e.Id).HasColumnName("user_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Email).HasColumnName("email");
                entity.Property(e => e.Password).HasColumnName("password");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at").HasDefaultValue(DateTime.Now);
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
                entity.HasData(
                    new User { Id = 1, Email = "test@test.com", Password = "test", Name = "test" }
                    );
            });
            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");
                entity.ToTable("survey_questions");
                entity.Property(e => e.Id).HasColumnName("question_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.SurveyId).HasColumnName("survey_id");
                entity.Property(e => e.Multiple).HasColumnName("multiple").HasDefaultValue(false);
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
                entity.HasMany(s => s.Answers)
                .WithOne(c => c.Question);

            });
            modelBuilder.Entity<Answer>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");
                entity.ToTable("survey_answers");
                entity.Property(e => e.Id).HasColumnName("answer_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.QuestionId).HasColumnName("question_id");
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");

            });
            modelBuilder.Entity<Response>(entity =>
            {
                entity.ToTable("responses");
                entity.Property(e => e.Id).HasColumnName("response_id");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at").HasDefaultValue(DateTime.Now);
                entity.Property(e => e.SurveyId).HasColumnName("survey_id");
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");

            });
            modelBuilder.Entity<ResponseQuestion>(entity =>
            {
                entity.ToTable("response_questions");
                entity.Property(e => e.Id).HasColumnName("response_question_id");
                entity.Property(e => e.QuestionId).HasColumnName("question_id");
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");

            });
            modelBuilder.Entity<ResponseAnswer>(entity =>
            {
                entity.ToTable("response_answers");
                entity.Property(e => e.Id).HasColumnName("response_answer_id");
                entity.Property(e => e.AnswerId).HasColumnName("answer_id");
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");


            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
