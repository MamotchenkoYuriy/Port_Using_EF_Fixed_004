using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using DataAccessLayer.Repository;
using DataAccessLayer.Validation;

namespace DataAccessLayer.Manager
{
    public class Manager<T> : IManager<T> where T :BaseEntity
    {
        private readonly IValidator _validator;
        private readonly IRepository<T> _repository;

        public Manager(IRepository<T> repository, IValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public void Add(T entity)
        {
            if (_validator.IsValid(entity))
            {
                _repository.Add(entity);
            }
        }

        public void Remove(T entity)
        {
            _repository.Remove(entity);
        }

        public void Remove(int id)
        {
            _repository.Remove(id);
        }

        public void SaveChanges()
        {
            _repository.SaveChanges();
        }

        public DbSet<T> FindAll()
        {
            return _repository.FindAll();
        }

        public T Find(int id)
        {
            return _repository.Find(id);
        }

        public int Count => _repository.Count;

        public IQueryable<int> ListId()
        {
            return _repository.ListId();
        }
    }
}
