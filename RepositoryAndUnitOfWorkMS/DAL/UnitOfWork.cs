using System;
using RepositoryAndUnitOfWorkMS.Models;

namespace RepositoryAndUnitOfWorkMS.DAL
{
    public class UnitOfWork : IDisposable
    {

        private SchoolContext context = new SchoolContext();
        private GenericRepository<Enrollment> enrollmentRepository;
        private GenericRepository<Course> courseRepository;
        public GenericRepository<Enrollment> EnrollmentRepository
        {
            get
            {
                if (this.enrollmentRepository == null)
                {
                    this.enrollmentRepository = new GenericRepository<Enrollment>();
                }
                return enrollmentRepository;
            }

        }


        public GenericRepository<Course> CourseRepository
        {
            get
            {
                if (courseRepository == null)
                {
                    courseRepository = new GenericRepository<Course>();
                }
                return courseRepository;
            }
        }


        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}