using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using DataAccessLayer.Repository;

namespace DataAccessLayer.Validation
{
    class CargoValidator : IValidator
    {
        private readonly IRepository<Cargo> _repository;

        public CargoValidator(IRepository<Cargo> repository)
        {
            _repository = repository;
        }

        public bool IsValid(BaseEntity entity)
        {
            if (entity.GetType() != typeof(Cargo)) return false;
            var cargo = (Cargo)entity;
            return _repository.FindAll().FirstOrDefault(m => m.Number == cargo.Number) == null;
        }
    }
}
