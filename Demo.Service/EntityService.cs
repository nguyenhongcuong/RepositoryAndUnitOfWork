using System;
using System.Collections.Generic;
using Demo.Models;
using Demo.Repository;

namespace Demo.Service
{
    public abstract class EntityService<T> : IEntityService<T> where T : BaseEntity
    {
        private IUnitOfWork _unitOfWork;
        private IGenericRepository<T> _repository;

        public EntityService(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        public virtual void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _repository.Add(entity);
            _unitOfWork.Commit();
        }

        public virtual void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _repository.Delete(entity);
            _unitOfWork.Commit();
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _repository.Edit(entity);
            _unitOfWork.Commit();
        }
    }
}
