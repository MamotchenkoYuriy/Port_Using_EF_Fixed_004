using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using DataAccessLayer.Repository;

namespace DataAccessLayer.Validation
{
    public class CityValidator : IValidator
    {
        private readonly IRepository<City> _repository;

        public CityValidator(IRepository<City> repository)
        {
            _repository = repository;
        }

        public bool IsValid(BaseEntity entity)
        {
            if (entity.GetType() != typeof(City)) return false;
            var city = (City)entity;
            return _repository.FindAll().FirstOrDefault(m => m.Name == city.Name) == null;
        }
    }
}
