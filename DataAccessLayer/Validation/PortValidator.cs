using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using DataAccessLayer.Repository;

namespace DataAccessLayer.Validation
{
    public class PortValidator : IValidator
    {
        private readonly IRepository<Port> _repository;

        public PortValidator(IRepository<Port> repository)
        {
            _repository = repository;
        }

        public bool IsValid(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
