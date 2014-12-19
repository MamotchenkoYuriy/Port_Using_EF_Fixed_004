using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using DataAccessLayer.Repository;

namespace DataAccessLayer.Validation
{
    public class CargoTypeValidator :IValidator
    {
        private readonly IRepository<CargoType> _repository;

        public CargoTypeValidator(IRepository<CargoType> repository)
        {
            _repository = repository;
        }

        public bool IsValid(BaseEntity entity)
        {
            if (entity.GetType() != typeof(CargoType)) return false;
            var cargoType = (CargoType)entity;
            return _repository.FindAll().FirstOrDefault(m => m.TypeName == cargoType.TypeName) == null;
        }
    }
}
