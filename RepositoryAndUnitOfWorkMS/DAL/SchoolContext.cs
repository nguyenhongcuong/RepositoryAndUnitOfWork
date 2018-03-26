using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using RepositoryAndUnitOfWorkMS.Models;

namespace RepositoryAndUnitOfWorkMS.DAL
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Ngăn cho tên bảng không được thay đổi
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}