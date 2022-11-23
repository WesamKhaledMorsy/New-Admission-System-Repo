
using Admission.Manage.manageStudent;
using Admission.Model.DomainModel;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



namespace Admission.DB
{
    public class AppDbContext :IdentityDbContext<ApplicationUser, ApplicationRole ,string>
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<University> Universities   { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Interviewer> Interviewers { get; set; }
        public  DbSet<Admin> Admins { get; set; }

        public DbSet<ApplicationUser> Users { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Status>()
        //        .Property(st => st.StatusName)
        //        .HasDefaultValueSql("Waiting for Interview");
        //    modelBuilder.Entity<StudentDTO>()
        //        .Property(stud => stud.StatusName)
        //        .HasDefaultValueSql("Waiting for Interview");

        //    //modelBuilder.Entity<IdentityUserLogin>()
        //    //    .HasNoKey();
        //}
    }
}
