using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TutorWebContext : DbContext
    {
        public TutorWebContext() { }
        public TutorWebContext(DbContextOptions<TutorWebContext> options) : base(options) { }
        public DbSet<Event> Events { get; set; }
        public DbSet<Contract> Contacts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<StudentDetails> Students { get; set; }
        public DbSet<TutionFeeSchedule> TutionFeeSchedules { get; set; }
        public DbSet<TutorDetails> Tutors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<TutorAdvertisement> TutorAdvertisements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                IConfigurationRoot configuration = builder.Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("TutorWebDB"));
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasOne(t => t.Role)
                .WithMany(t => t.Users)
                .HasForeignKey(p => p.RoleId);
            //
            /*Tutor-TutionFeeSchedule*/
            //
            modelBuilder.Entity<TutionFeeSchedule>()
                .HasOne(t => t.Tutor)
                .WithMany(t => t._tutionFeeSchedules)
                .HasForeignKey(p => p.TutorId);
            //
            /*Course-TutionFeeSchedule*/
            //
            modelBuilder.Entity<TutionFeeSchedule>()
                .HasOne(t => t.Course)
                .WithMany(t => t._TutionFeeSchedules)
                .HasForeignKey(p => p.CourseId);
            //
            /*Tutor-TutorAdvertisement*/
            //
            modelBuilder.Entity<TutorAdvertisement>()
                .HasOne(t => t.Tutor)
                .WithMany(t => t._TutorAdvertisements)
                .HasForeignKey(p => p.TutorId);
            //
            /*Tutor-FreeCourse*/
            //
            modelBuilder.Entity<FreeCourse>()
                .HasOne(t => t.Tutor)
                .WithMany(t => t._FreeCourse)
                .HasForeignKey(p => p.TutorId);

            //
            /*Contract-Student*/
            //
            modelBuilder.Entity<Contract>()
                .HasOne(c => c.Student)
                .WithMany(t => t.Contacts)
                .HasForeignKey(p => p.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
            //
            //
            /*Contract-Tutor*/
            //
            modelBuilder.Entity<Contract>()
                .HasOne(c => c.Tutor)
                .WithMany(t => t.Contacts)
                .HasForeignKey(p => p.TutorId)
                .OnDelete(DeleteBehavior.Cascade);
            //*/
            /*User-Student*/
            //
            modelBuilder.Entity<StudentDetails>()
                .HasOne(s => s.User)
                .WithOne(u => u._Student)
                .HasForeignKey<StudentDetails>(s => s.UserId);
            //
            /*User-Tutor*/
            //
            modelBuilder.Entity<TutorDetails>()
                .HasOne(s => s.User)
                .WithOne(u => u._Tutor)
                .HasForeignKey<TutorDetails>(s => s.UserId);
            //
            /*User-Feedback-Send*/
            //
            modelBuilder.Entity<Feedback>()
                .HasOne(s => s.Commenter)
                .WithMany(u => u._Feedbacks)
                .HasForeignKey(s => s.CommenterId);
            //
            /*User-Feedback-Receive*/
            //
            modelBuilder.Entity<Feedback>()
                .HasOne(t => t.Tutor)
                .WithMany(f => f._FeedbacksAbout)
                .HasForeignKey(f => f.TutorId);
            modelBuilder.Entity<Feedback>()
                .HasOne(t => t.Receiver)
                .WithMany(f => f._FeedbacksAbout)
                .HasForeignKey(f => f.ReceiverId);
            //
            /*User-Location*/
            //
            modelBuilder.Entity<User>()
                .HasOne(s => s.Location)
                .WithMany(u => u._Users)
                .HasForeignKey(s => s.LocationId);
            //
            /*Admin-Events*/
            //
            modelBuilder.Entity<Event>()
                .HasOne(s => s.Admin)
                .WithMany(u => u._Events)
                .HasForeignKey(s => s.AdminId);
            //
            /*Invoice-Contract*/
            //
            modelBuilder.Entity<Invoice>()
                .HasOne(s => s.Contract)
                .WithOne(u => u.Invoice)
                .HasForeignKey<Invoice>(s => s.ContractId);
            //
            /*StudentRequirement*/
            //
            modelBuilder.Entity<StudentRequirement>()
                .HasKey(m => new { m.StudentId, m.CourseId });
            modelBuilder.Entity<StudentRequirement>()
                .HasOne(s => s.Student)
                .WithMany(u => u._StudentRequirements)
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<StudentRequirement>()
                .HasOne(s => s.Course)
                .WithMany(u => u._StudentRequirements)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
            //
            /*Students-Courses*/
            //
            modelBuilder.Entity<StudyCourse>()
                .HasKey(m => new { m.StudentId, m.CourseId });
            modelBuilder.Entity<StudyCourse>()
                .HasOne(s => s.Student)
                .WithMany(u => u._StudyingCourses)
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<StudyCourse>()
                .HasOne(s => s.Course)
                .WithMany(u => u._StudyingCourses)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
            //Role-Seeder
            modelBuilder.Entity<Role>()
                .HasData(
                new { RoleId = Guid.NewGuid(), RoleName = "Admin", Status = "None" },
                new { RoleId = Guid.NewGuid(), RoleName = "Student", Status = "None" },
                new { RoleId = Guid.NewGuid(), RoleName = "Tutor", Status = "None" }
                );
            //Location-Seeder
            modelBuilder.Entity<Location>()
                .HasData(
                new { LocationId = Guid.NewGuid(), CityOrProvince = "Da Nang", District = "Hai Chau" },
                new { LocationId = Guid.NewGuid(), CityOrProvince = "Da Nang", District = "Thank Khe" },
                new { LocationId = Guid.NewGuid(), CityOrProvince = "Da Nang", District = "Son Tra" }
                );
        }
    }

}
