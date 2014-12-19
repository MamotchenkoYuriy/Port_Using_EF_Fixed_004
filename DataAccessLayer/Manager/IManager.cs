using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace DataAccessLayer.Manager
{
    public interface IManager<T> where T :BaseEntity
    {
        void Add(T entity);
        void Remove(T entity);
        void Remove(int id);
        void SaveChanges();
        DbSet<T> FindAll();
        T Find(int id);
        int Count { get; }

        IQueryable<int> ListId();
    }
}
