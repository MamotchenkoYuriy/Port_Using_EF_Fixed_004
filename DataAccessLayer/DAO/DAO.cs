using System.Collections.Generic;
using Core;
using DataAccessLayer.DataContextConfiguration;
using DataAccessLayer.Repository;

namespace DataAccessLayer.DAO
{
    public class DAO
    {
        private readonly DataContext _dataContext;
        private static DAO _instanceDao;
        private readonly Dictionary<string, object> _dictionary; 

        private DAO ()
        {
            _dataContext = new DataContext();
            _dictionary = new Dictionary<string, object>();
        }

        public static DAO GetInstance()
        {
            if (_instanceDao != null)
            {
                return _instanceDao;
            }
            _instanceDao = new DAO();
            return _instanceDao;
        }

        public IRepository<T> Repository<T>() where T : BaseEntity
        {
            if (_dictionary.ContainsKey(typeof (T).Name))
            {
                return _dictionary[typeof (T).Name] as IRepository<T>;
            }
            _dictionary.Add(typeof(T).Name, new Repository<T>(_dataContext));
            return _dictionary[typeof(T).Name] as IRepository<T>;
        }
    }
}
