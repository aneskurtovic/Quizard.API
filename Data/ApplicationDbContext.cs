using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Quizard.API.Models;

namespace Quizard.API.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<QuestionCategory> QuestionsCategories { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            const string ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            const string ROLE_ID = ADMIN_ID;
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = ROLE_ID,
                Name = "admin",
                NormalizedName = "admin"
            });

            var hasher = new PasswordHasher<IdentityUser>();
            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = ADMIN_ID,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "admin@tacta.io",
                NormalizedEmail = "admin@tacta.io",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "admin123"),
                SecurityStamp = string.Empty
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });

            builder.Entity<QuestionCategory>()
                .HasKey(t => new { t.CategoryID, t.QuestionID });

            builder.Entity<QuestionCategory>()
                .HasOne(pt => pt.Question)
                .WithMany(p => p.QuestionsCategories)
                .HasForeignKey(pt => pt.QuestionID);

            builder.Entity<QuestionCategory>()
                .HasOne(pt => pt.Category)
                .WithMany(t => t.QuestionsCategories)
                .HasForeignKey(pt => pt.CategoryID);
        }

    }
}
