using Microsoft.EntityFrameworkCore;

namespace Chapter6Example1.Models
{ 
    public class SchoolDbContext : DbContext
    {
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public SchoolDbContext ( DbContextOptions <SchoolDbContext> options ) : base( options )
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }  

    }
}
