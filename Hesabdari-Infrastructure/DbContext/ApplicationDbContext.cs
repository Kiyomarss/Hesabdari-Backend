using ContactsManager.Core.Domain.IdentityEntities;
using Hesabdari_Core.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using RepositoryContracts;

namespace Hesabdari_Infrastructure.DbContext
{
 public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>, IApplicationDbContext
 {
  public ApplicationDbContext(DbContextOptions options) : base(options) { }
  
  public DatabaseFacade Database => base.Database;
  
  //TODO: خطوط زیر نباید حذف شود زیر اجرای مایگریشن به مشکل می‌خورد
  public DbSet<HeroSlide> HeroSlides { get; set; }
  public DbSet<Setting> Settings { get; set; }
  public DbSet<Testimonial> Testimonials { get; set; }
  public DbSet<TeamMember> TeamMembers { get; set; }
  public DbSet<ConsultationRequest> ConsultationRequests { get; set; }
  public DbSet<Course> Courses { get; set; }
  public DbSet<Chapter> Chapters { get; set; }
  public DbSet<Lesson> Lessons { get; set; }
  public DbSet<UserCourse> UserCourses { get; set; }

  public new EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class => base.Entry(entity);
  
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
   base.OnModelCreating(modelBuilder);

   modelBuilder.Entity<HeroSlide>().ToTable("HeroSlides");
   modelBuilder.Entity<Setting>().ToTable("Setting");
   modelBuilder.Entity<Testimonial>().ToTable("Testimonials");
   modelBuilder.Entity<TeamMember>().ToTable("TeamMembers");
   modelBuilder.Entity<ConsultationRequest>().ToTable("ConsultationRequests");
   modelBuilder.Entity<Course>().ToTable("Courses");
   modelBuilder.Entity<Chapter>().ToTable("Chapters");
   modelBuilder.Entity<Lesson>().ToTable("Lessons");
   modelBuilder.Entity<UserCourse>().ToTable("UserCourses");

   modelBuilder.Entity<Course>()
               .HasMany(c => c.Chapters)
               .WithOne(ch => ch.Course)
               .HasForeignKey(ch => ch.CourseId)
               .OnDelete(DeleteBehavior.Cascade);

   modelBuilder.Entity<Chapter>()
               .HasMany(ch => ch.Lessons)
               .WithOne(l => l.Chapter)
               .HasForeignKey(l => l.ChapterId)
               .OnDelete(DeleteBehavior.Cascade);
   
   modelBuilder.Entity<UserCourse>()
               .HasOne(uc => uc.User)
               .WithMany()
               .HasForeignKey(uc => uc.UserId)
               .OnDelete(DeleteBehavior.Cascade);

   modelBuilder.Entity<UserCourse>()
               .HasOne(uc => uc.Course)
               .WithMany()
               .HasForeignKey(uc => uc.CourseId)
               .OnDelete(DeleteBehavior.Cascade);
  }
 }
}
