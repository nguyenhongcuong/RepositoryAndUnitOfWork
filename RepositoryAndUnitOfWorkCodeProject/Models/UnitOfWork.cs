using System;
using RepositoryAndUnitOfWorkCodeProject.DAL;

namespace RepositoryAndUnitOfWorkCodeProject.Models
{
    public class UnitOfWork : IDisposable
    {
        private ContosoUniversityEntities entities = null;

        public UnitOfWork()
        {
            entities = new ContosoUniversityEntities();
        }

        private IRepository<Student> studentRepository = null;

        public IRepository<Student> StudentRepository
        {
            get
            {
                if (studentRepository == null)
                {
                    studentRepository = new StudentRepositoryWithUnitOfWork(entities);
                }
                return studentRepository;
            }
        }

        public virtual void Save()
        {
            entities.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    entities.Dispose();
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