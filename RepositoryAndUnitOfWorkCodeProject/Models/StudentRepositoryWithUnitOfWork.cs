using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using RepositoryAndUnitOfWorkCodeProject.DAL;

namespace RepositoryAndUnitOfWorkCodeProject.Models
{
    public class StudentRepositoryWithUnitOfWork : IRepository<Student>
    {
        private ContosoUniversityEntities entities = null;

        public StudentRepositoryWithUnitOfWork(ContosoUniversityEntities entities)
        {
            this.entities = entities;
        }
        public IEnumerable<Student> GetAll(Func<Student, bool> predicate = null)
        {
            return predicate != null ? entities.Student.Where(predicate) : entities.Student;
        }

        public Student Get(Func<Student, bool> predicate)
        {
            return entities.Student.FirstOrDefault(predicate);
        }

        public void Add(Student entity)
        {
            entities.Student.Add(entity);
        }

        public void Attach(Student entity)
        {
            entities.Student.Attach(entity);
            entities.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Student entity)
        {
            entities.Student.Remove(entity);
        }
    }
}